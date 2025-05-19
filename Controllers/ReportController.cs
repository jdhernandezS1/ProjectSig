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
    }

}