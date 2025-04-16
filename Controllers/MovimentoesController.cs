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
    public class MovimentoesController : Controller
    {
        private readonly PostgresContext _context;

        public MovimentoesController(PostgresContext context)
        {
            _context = context;
        }

        // GET: Movimentoes
        public async Task<IActionResult> Index()
        {
            var postgresContext = _context.Movimentos.Include(m => m.IdnoleggioNavigation).Include(m => m.PagamentoNavigation);
            return View(await postgresContext.ToListAsync());
        }

        // GET: Movimentoes/Details/5
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

        // GET: Movimentoes/Create
        public IActionResult Create()
        {
            ViewData["Idnoleggio"] = new SelectList(_context.Noleggios, "Idnoleggio", "Idnoleggio");
            ViewData["Pagamento"] = new SelectList(_context.Tipopagamentos, "Pagamento", "Pagamento");
            return View();
        }

        // POST: Movimentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmovimento,Idnoleggio,Cauzione,Data,Pagamento")] Movimento movimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idnoleggio"] = new SelectList(_context.Noleggios, "Idnoleggio", "Idnoleggio", movimento.Idnoleggio);
            ViewData["Pagamento"] = new SelectList(_context.Tipopagamentos, "Pagamento", "Pagamento", movimento.Pagamento);
            return View(movimento);
        }

        // GET: Movimentoes/Edit/5
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
            ViewData["Pagamento"] = new SelectList(_context.Tipopagamentos, "Pagamento", "Pagamento", movimento.Pagamento);
            return View(movimento);
        }

        // POST: Movimentoes/Edit/5
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
            ViewData["Pagamento"] = new SelectList(_context.Tipopagamentos, "Pagamento", "Pagamento", movimento.Pagamento);
            return View(movimento);
        }

        // GET: Movimentoes/Delete/5
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

        // POST: Movimentoes/Delete/5
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
