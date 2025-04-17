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
    public class TipopagamentosController : Controller
    {
        private readonly PostgresContext _context;

        public TipopagamentosController(PostgresContext context)
        {
            _context = context;
        }

        // GET: Tipopagamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipopagamentos.ToListAsync());
        }

        // GET: Tipopagamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipopagamento = await _context.Tipopagamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipopagamento == null)
            {
                return NotFound();
            }

            return View(tipopagamento);
        }

        // GET: Tipopagamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipopagamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Pagamento")] Tipopagamento tipopagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipopagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipopagamento);
        }

        // GET: Tipopagamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: Tipopagamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Pagamento")] Tipopagamento tipopagamento)
        {
            if (id != tipopagamento.Id)
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
                    if (!TipopagamentoExists(tipopagamento.Id))
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

        // GET: Tipopagamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipopagamento = await _context.Tipopagamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipopagamento == null)
            {
                return NotFound();
            }

            return View(tipopagamento);
        }

        // POST: Tipopagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipopagamento = await _context.Tipopagamentos.FindAsync(id);
            if (tipopagamento != null)
            {
                _context.Tipopagamentos.Remove(tipopagamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipopagamentoExists(int id)
        {
            return _context.Tipopagamentos.Any(e => e.Id == id);
        }
    }
}
