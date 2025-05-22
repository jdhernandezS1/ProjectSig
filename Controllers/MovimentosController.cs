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
    public class MovimentosController : Controller
    {
        private readonly PostgresContext _context;

        public MovimentosController(PostgresContext context)
        {
            _context = context;
        }

        // GET: Movimentos
        public async Task<IActionResult> Index()
        {
            var postgresContext = _context.Movimentos.Include(m => m.IdnoleggioNavigation).Include(m => m.PagamentoNavigation);
            return View(await postgresContext.ToListAsync());
        }

        // GET: Movimento/5
        public async Task<IActionResult> Movimento(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentos = await _context.Movimentos
                    .Where(m => m.Idnoleggio == id)
                    .Include(m => m.IdnoleggioNavigation)
                    .Include(m => m.PagamentoNavigation)
                    .ToListAsync();

            if (movimentos == null)
            {
                return NotFound();
            }
            ViewBag.Idnoleggio = id;
            return View(movimentos);
        }

        // GET: Movimentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimento = await _context.Movimentos
                .Include(m => m.IdnoleggioNavigation)
                .Include(m => m.PagamentoNavigation)
                .FirstOrDefaultAsync(m => m.Idmovimento == id);
            if (movimento == null)
            {
                return NotFound();
            }

            return View(movimento);
        }

        // GET: Movimentos/Create
        public IActionResult Create(int? id)
        {
            if (id.HasValue)
            {
                ViewData["Idnoleggio"] = new SelectList(_context.Noleggios, "Idnoleggio", "Idnoleggio", id.Value);
            }
            else
            {
                ViewData["Idnoleggio"] = new SelectList(_context.Noleggios, "Idnoleggio", "Idnoleggio");
            }

            ViewData["Pagamento"] = new SelectList(_context.Tipopagamentos, "Id", "Pagamento");
            return View();
        }

        // POST: Movimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmovimento,Idnoleggio,Cauzione,Data,Pagamento")] Movimento movimento)
        {
            if (ModelState.IsValid)
            {
                movimento.Data = DateTime.SpecifyKind(movimento.Data, DateTimeKind.Utc);
                _context.Add(movimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idnoleggio"] = new SelectList(_context.Noleggios, "Idnoleggio", "Idnoleggio", movimento.Idnoleggio);
            ViewData["Pagamento"] = new SelectList(_context.Tipopagamentos, "Id", "Pagamento", movimento.Pagamento);
            return View(movimento);
        }

        // GET: Movimentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimento = await _context.Movimentos.FindAsync(id);
            if (movimento == null)
            {
                return NotFound();
            }
            ViewData["Idnoleggio"] = new SelectList(_context.Noleggios, "Idnoleggio", "Idnoleggio", movimento.Idnoleggio);
            ViewData["Pagamento"] = new SelectList(_context.Tipopagamentos, "Id", "Pagamento", movimento.Pagamento);
            return View(movimento);
        }

        // POST: Movimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idmovimento,Idnoleggio,Cauzione,Data,Pagamento")] Movimento movimento)
        {
            if (id != movimento.Idmovimento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    movimento.Data = DateTime.SpecifyKind(movimento.Data, DateTimeKind.Utc);
                    _context.Update(movimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimentoExists(movimento.Idmovimento))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idnoleggio"] = new SelectList(_context.Noleggios, "Idnoleggio", "Idnoleggio", movimento.Idnoleggio);
            ViewData["Pagamento"] = new SelectList(_context.Tipopagamentos, "Id", "Pagamento", movimento.Pagamento);
            return View(movimento);
        }

        // GET: Movimentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimento = await _context.Movimentos
                .Include(m => m.IdnoleggioNavigation)
                .Include(m => m.PagamentoNavigation)
                .FirstOrDefaultAsync(m => m.Idmovimento == id);
            if (movimento == null)
            {
                return NotFound();
            }

            return View(movimento);
        }

        // POST: Movimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimento = await _context.Movimentos.FindAsync(id);
            if (movimento != null)
            {
                _context.Movimentos.Remove(movimento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimentoExists(int id)
        {
            return _context.Movimentos.Any(e => e.Idmovimento == id);
        }
    }
}
