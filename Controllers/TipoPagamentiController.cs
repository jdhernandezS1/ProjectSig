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
    public class TipoPagamentiController : Controller
    {
        private readonly AppDbContext _context;

        public TipoPagamentiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TipoPagamenti
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoPagamentoModel.ToListAsync());
        }

        // GET: TipoPagamenti/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPagamentoModel = await _context.TipoPagamentoModel
                .FirstOrDefaultAsync(m => m.Pagamento == id);
            if (tipoPagamentoModel == null)
            {
                return NotFound();
            }

            return View(tipoPagamentoModel);
        }

        // GET: TipoPagamenti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPagamenti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Pagamento")] TipoPagamentoModel tipoPagamentoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPagamentoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPagamentoModel);
        }

        // GET: TipoPagamenti/Edit/5
        public async Task<IActionResult> Edit(string id)
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

        // POST: TipoPagamenti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Pagamento")] TipoPagamentoModel tipoPagamentoModel)
        {
            if (id != tipoPagamentoModel.Pagamento)
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
                    if (!TipoPagamentoModelExists(tipoPagamentoModel.Pagamento))
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

        // GET: TipoPagamenti/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoPagamentoModel = await _context.TipoPagamentoModel
                .FirstOrDefaultAsync(m => m.Pagamento == id);
            if (tipoPagamentoModel == null)
            {
                return NotFound();
            }

            return View(tipoPagamentoModel);
        }

        // POST: TipoPagamenti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tipoPagamentoModel = await _context.TipoPagamentoModel.FindAsync(id);
            if (tipoPagamentoModel != null)
            {
                _context.TipoPagamentoModel.Remove(tipoPagamentoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPagamentoModelExists(string id)
        {
            return _context.TipoPagamentoModel.Any(e => e.Pagamento == id);
        }
    }
}
