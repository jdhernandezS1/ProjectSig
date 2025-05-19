using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using armadieti2.Models;

namespace armadieti2.Controllers
{
    public class ReportController : Controller
    {
        private readonly PostgresContext _context;

        public ReportController(PostgresContext context)
        {
            _context = context;
        }

        // GET: Reports/MovimentiPerPeriodo
        public IActionResult MovimentiPerPeriodo()
        {
            return View();
        }

        // POST: Reports/MovimentiPerPeriodo
        [HttpPost]
        public async Task<IActionResult> MovimentiPerPeriodo(DateTime dataInizio, DateTime dataFine)
        {
            var inizioUtc = dataInizio.Date.ToUniversalTime();
            var fineUtc = dataFine.Date.AddDays(1).ToUniversalTime(); // Include tutto il giorno finale

            var movimenti = await _context.Movimentos
                .Include(m => m.PagamentoNavigation)
                .Include(m => m.IdnoleggioNavigation)
                    .ThenInclude(n => n.IdpersonaNavigation)
                .Where(m => m.Data >= inizioUtc && m.Data < fineUtc)
                .ToListAsync();

            var totale = movimenti.Sum(m => m.Cauzione);

            ViewBag.DataInizio = dataInizio.ToString("yyyy-MM-dd");
            ViewBag.DataFine = dataFine.ToString("yyyy-MM-dd");
            ViewBag.Totale = totale;

            return View("MovimentiPerPeriodo", movimenti);
        }
        [HttpPost]
        public async Task<IActionResult> ExportExcel(DateTime dataInizio, DateTime dataFine)
        {
            var inizioUtc = dataInizio.Date.ToUniversalTime();
            var fineUtc = dataFine.Date.AddDays(1).ToUniversalTime();

            var movimenti = await _context.Movimentos
                .Include(m => m.PagamentoNavigation)
                .Include(m => m.IdnoleggioNavigation)
                    .ThenInclude(n => n.IdpersonaNavigation)
                .Where(m => m.Data >= inizioUtc && m.Data < fineUtc)
                .ToListAsync();

            using var workbook = new ClosedXML.Excel.XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Contabilità");

            // Intestazioni
            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Data";
            worksheet.Cell(1, 3).Value = "Importo (CHF)";
            worksheet.Cell(1, 4).Value = "Pagamento";
            worksheet.Cell(1, 5).Value = "Persona";

            int row = 2;
            foreach (var movimento in movimenti)
            {
                worksheet.Cell(row, 1).Value = movimento.Idmovimento;
                worksheet.Cell(row, 2).Value = movimento.Data.ToLocalTime().ToString("dd/MM/yyyy");
                worksheet.Cell(row, 3).Value = movimento.Cauzione;
                worksheet.Cell(row, 4).Value = movimento.PagamentoNavigation?.Pagamento;
                worksheet.Cell(row, 5).Value = movimento.IdnoleggioNavigation?.IdpersonaNavigation?.Cognome;
                row++;
            }

            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            string fileName = $"Contabilita_{dataInizio:yyyyMMdd}_{dataFine:yyyyMMdd}.xlsx";
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

    }

}