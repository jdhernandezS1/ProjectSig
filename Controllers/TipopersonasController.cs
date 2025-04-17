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
    public class TipopersonasController : Controller
    {
        private readonly PostgresContext _context;

        public TipopersonasController(PostgresContext context)
        {
            _context = context;
        }

        // GET: Tipopersonas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipopersonas.ToListAsync());
        }

        // GET: Tipopersonas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipopersona = await _context.Tipopersonas
                .FirstOrDefaultAsync(m => m.IdTiPersona == id);
            if (tipopersona == null)
            {
                return NotFound();
            }

            return View(tipopersona);
        }

        // GET: Tipopersonas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipopersonas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTiPersona,Tipopersona1")] Tipopersona tipopersona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipopersona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipopersona);
        }

        // GET: Tipopersonas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipopersona = await _context.Tipopersonas.FindAsync(id);
            if (tipopersona == null)
            {
                return NotFound();
            }
            return View(tipopersona);
        }

        // POST: Tipopersonas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTiPersona,Tipopersona1")] Tipopersona tipopersona)
        {
            if (id != tipopersona.IdTiPersona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipopersona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipopersonaExists(tipopersona.IdTiPersona))
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
            return View(tipopersona);
        }

        // GET: Tipopersonas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipopersona = await _context.Tipopersonas
                .FirstOrDefaultAsync(m => m.IdTiPersona == id);
            if (tipopersona == null)
            {
                return NotFound();
            }

            return View(tipopersona);
        }

        // POST: Tipopersonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipopersona = await _context.Tipopersonas.FindAsync(id);
            if (tipopersona != null)
            {
                _context.Tipopersonas.Remove(tipopersona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipopersonaExists(int id)
        {
            return _context.Tipopersonas.Any(e => e.IdTiPersona == id);
        }
    }
}
