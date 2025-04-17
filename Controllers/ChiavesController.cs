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
    public class ChiavesController : Controller
    {
        private readonly PostgresContext _context;

        public ChiavesController(PostgresContext context)
        {
            _context = context;
        }

        // GET: Chiaves
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chiaves.ToListAsync());
        }

        // GET: Chiaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiave = await _context.Chiaves
                .FirstOrDefaultAsync(m => m.id == id);
            if (chiave == null)
            {
                return NotFound();
            }

            return View(chiave);
        }

        // GET: Chiaves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chiaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Numerochiave")] Chiave chiave)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiave);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chiave);
        }

        // GET: Chiaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiave = await _context.Chiaves.FindAsync(id);
            if (chiave == null)
            {
                return NotFound();
            }
            return View(chiave);
        }

        // POST: Chiaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Numerochiave")] Chiave chiave)
        {
            if (id != chiave.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiaveExists(chiave.id))
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
            return View(chiave);
        }

        // GET: Chiaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiave = await _context.Chiaves
                .FirstOrDefaultAsync(m => m.id == id);
            if (chiave == null)
            {
                return NotFound();
            }

            return View(chiave);
        }

        // POST: Chiaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiave = await _context.Chiaves.FindAsync(id);
            if (chiave != null)
            {
                _context.Chiaves.Remove(chiave);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiaveExists(int id)
        {
            return _context.Chiaves.Any(e => e.id == id);
        }
    }
}
