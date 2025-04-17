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
    public class DipartimentosController : Controller
    {
        private readonly PostgresContext _context;

        public DipartimentosController(PostgresContext context)
        {
            _context = context;
        }

        // GET: Dipartimentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dipartimentos.ToListAsync());
        }

        // GET: Dipartimentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dipartimento = await _context.Dipartimentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dipartimento == null)
            {
                return NotFound();
            }

            return View(dipartimento);
        }

        // GET: Dipartimentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dipartimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nomedipartimento")] Dipartimento dipartimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dipartimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dipartimento);
        }

        // GET: Dipartimentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: Dipartimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nomedipartimento")] Dipartimento dipartimento)
        {
            if (id != dipartimento.Id)
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
                    if (!DipartimentoExists(dipartimento.Id))
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

        // GET: Dipartimentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dipartimento = await _context.Dipartimentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dipartimento == null)
            {
                return NotFound();
            }

            return View(dipartimento);
        }

        // POST: Dipartimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dipartimento = await _context.Dipartimentos.FindAsync(id);
            if (dipartimento != null)
            {
                _context.Dipartimentos.Remove(dipartimento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DipartimentoExists(int id)
        {
            return _context.Dipartimentos.Any(e => e.Id == id);
        }
    }
}
