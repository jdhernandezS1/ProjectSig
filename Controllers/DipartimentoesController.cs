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
    public class DipartimentoesController : Controller
    {
        private readonly PostgresContext _context;

        public DipartimentoesController(PostgresContext context)
        {
            _context = context;
        }

        // GET: Dipartimentoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dipartimentos.ToListAsync());
        }

        // GET: Dipartimentoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dipartimento = await _context.Dipartimentos
                .FirstOrDefaultAsync(m => m.Nomedipartimento == id);
            if (dipartimento == null)
            {
                return NotFound();
            }

            return View(dipartimento);
        }

        // GET: Dipartimentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dipartimentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nomedipartimento")] Dipartimento dipartimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dipartimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dipartimento);
        }

        // GET: Dipartimentoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dipartimento = await _context.Dipartimentos.FindAsync(id);
            if (dipartimento == null)
            {
                return NotFound();
            }
            return View(dipartimento);
        }

        // POST: Dipartimentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nomedipartimento")] Dipartimento dipartimento)
        {
            if (id != dipartimento.Nomedipartimento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dipartimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DipartimentoExists(dipartimento.Nomedipartimento))
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
            return View(dipartimento);
        }

        // GET: Dipartimentoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dipartimento = await _context.Dipartimentos
                .FirstOrDefaultAsync(m => m.Nomedipartimento == id);
            if (dipartimento == null)
            {
                return NotFound();
            }

            return View(dipartimento);
        }

        // POST: Dipartimentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dipartimento = await _context.Dipartimentos.FindAsync(id);
            if (dipartimento != null)
            {
                _context.Dipartimentos.Remove(dipartimento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DipartimentoExists(string id)
        {
            return _context.Dipartimentos.Any(e => e.Nomedipartimento == id);
        }
    }
}
