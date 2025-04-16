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
    public class TipopagamentoesController : Controller
    {
        private readonly PostgresContext _context;

        public TipopagamentoesController(PostgresContext context)
        {
            _context = context;
        }

        // GET: Tipopagamentoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipopagamentos.ToListAsync());
        }

        // GET: Tipopagamentoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipopagamento = await _context.Tipopagamentos
                .FirstOrDefaultAsync(m => m.Pagamento == id);
            if (tipopagamento == null)
            {
                return NotFound();
            }

            return View(tipopagamento);
        }

        // GET: Tipopagamentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipopagamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pagamento")] Tipopagamento tipopagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipopagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipopagamento);
        }

        // GET: Tipopagamentoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipopagamento = await _context.Tipopagamentos.FindAsync(id);
            if (tipopagamento == null)
            {
                return NotFound();
            }
            return View(tipopagamento);
        }

        // POST: Tipopagamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Pagamento")] Tipopagamento tipopagamento)
        {
            if (id != tipopagamento.Pagamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipopagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipopagamentoExists(tipopagamento.Pagamento))
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
            return View(tipopagamento);
        }

        // GET: Tipopagamentoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipopagamento = await _context.Tipopagamentos
                .FirstOrDefaultAsync(m => m.Pagamento == id);
            if (tipopagamento == null)
            {
                return NotFound();
            }

            return View(tipopagamento);
        }

        // POST: Tipopagamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tipopagamento = await _context.Tipopagamentos.FindAsync(id);
            if (tipopagamento != null)
            {
                _context.Tipopagamentos.Remove(tipopagamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipopagamentoExists(string id)
        {
            return _context.Tipopagamentos.Any(e => e.Pagamento == id);
        }
    }
}
