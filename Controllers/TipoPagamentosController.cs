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
    public class TipoPagamentosController : Controller
    {
        private readonly AppDbContext _context;

        public TipoPagamentosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TipoPagamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoPagamentoModel.ToListAsync());
        }

        // GET: TipoPagamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPagamentoModel = await _context.TipoPagamentoModel
                .FirstOrDefaultAsync(m => m.IdTipoPagamento == id);
            if (tipoPagamentoModel == null)
            {
                return NotFound();
            }

            return View(tipoPagamentoModel);
        }

        // GET: TipoPagamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPagamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoPagamento,Pagamento")] TipoPagamentoModel tipoPagamentoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPagamentoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPagamentoModel);
        }

        // GET: TipoPagamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPagamentoModel = await _context.TipoPagamentoModel.FindAsync(id);
            if (tipoPagamentoModel == null)
            {
                return NotFound();
            }
            return View(tipoPagamentoModel);
        }

        // POST: TipoPagamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoPagamento,Pagamento")] TipoPagamentoModel tipoPagamentoModel)
        {
            if (id != tipoPagamentoModel.IdTipoPagamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPagamentoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPagamentoModelExists(tipoPagamentoModel.IdTipoPagamento))
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
            return View(tipoPagamentoModel);
        }

        // GET: TipoPagamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPagamentoModel = await _context.TipoPagamentoModel
                .FirstOrDefaultAsync(m => m.IdTipoPagamento == id);
            if (tipoPagamentoModel == null)
            {
                return NotFound();
            }

            return View(tipoPagamentoModel);
        }

        // POST: TipoPagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoPagamentoModel = await _context.TipoPagamentoModel.FindAsync(id);
            if (tipoPagamentoModel != null)
            {
                _context.TipoPagamentoModel.Remove(tipoPagamentoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPagamentoModelExists(int id)
        {
            return _context.TipoPagamentoModel.Any(e => e.IdTipoPagamento == id);
        }
    }
}
