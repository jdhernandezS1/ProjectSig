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
    public class TipomobiliosController : Controller
    {
        private readonly PostgresContext _context;

        public TipomobiliosController(PostgresContext context)
        {
            _context = context;
        }

        // GET: Tipomobilios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipomobilios.ToListAsync());
        }

        // GET: Tipomobilios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipomobilio = await _context.Tipomobilios
                .FirstOrDefaultAsync(m => m.id == id);
            if (tipomobilio == null)
            {
                return NotFound();
            }

            return View(tipomobilio);
        }

        // GET: Tipomobilios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipomobilios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Tipomobilio1")] Tipomobilio tipomobilio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipomobilio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipomobilio);
        }

        // GET: Tipomobilios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipomobilio = await _context.Tipomobilios.FindAsync(id);
            if (tipomobilio == null)
            {
                return NotFound();
            }
            return View(tipomobilio);
        }

        // POST: Tipomobilios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Tipomobilio1")] Tipomobilio tipomobilio)
        {
            if (id != tipomobilio.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipomobilio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipomobilioExists(tipomobilio.id))
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
            return View(tipomobilio);
        }

        // GET: Tipomobilios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipomobilio = await _context.Tipomobilios
                .FirstOrDefaultAsync(m => m.id == id);
            if (tipomobilio == null)
            {
                return NotFound();
            }

            return View(tipomobilio);
        }

        // POST: Tipomobilios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipomobilio = await _context.Tipomobilios.FindAsync(id);
            if (tipomobilio != null)
            {
                _context.Tipomobilios.Remove(tipomobilio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipomobilioExists(int id)
        {
            return _context.Tipomobilios.Any(e => e.id == id);
        }
    }
}
