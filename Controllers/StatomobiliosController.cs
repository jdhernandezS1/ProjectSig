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
    public class StatomobiliosController : Controller
    {
        private readonly PostgresContext _context;

        public StatomobiliosController(PostgresContext context)
        {
            _context = context;
        }

        // GET: Statomobilios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Statomobilios.ToListAsync());
        }

        // GET: Statomobilios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statomobilio = await _context.Statomobilios
                .FirstOrDefaultAsync(m => m.id == id);
            if (statomobilio == null)
            {
                return NotFound();
            }

            return View(statomobilio);
        }

        // GET: Statomobilios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Statomobilios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Statomobilio1")] Statomobilio statomobilio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statomobilio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statomobilio);
        }

        // GET: Statomobilios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statomobilio = await _context.Statomobilios.FindAsync(id);
            if (statomobilio == null)
            {
                return NotFound();
            }
            return View(statomobilio);
        }

        // POST: Statomobilios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Statomobilio1")] Statomobilio statomobilio)
        {
            if (id != statomobilio.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statomobilio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatomobilioExists(statomobilio.id))
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
            return View(statomobilio);
        }

        // GET: Statomobilios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statomobilio = await _context.Statomobilios
                .FirstOrDefaultAsync(m => m.id == id);
            if (statomobilio == null)
            {
                return NotFound();
            }

            return View(statomobilio);
        }

        // POST: Statomobilios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statomobilio = await _context.Statomobilios.FindAsync(id);
            if (statomobilio != null)
            {
                _context.Statomobilios.Remove(statomobilio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatomobilioExists(int id)
        {
            return _context.Statomobilios.Any(e => e.id == id);
        }
    }
}
