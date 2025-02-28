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
    public class ImpiegatiController : Controller
    {
        private readonly AppDbContext _context;

        public ImpiegatiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Impiegati
        public async Task<IActionResult> Index()
        {
            return View(await _context.Impiegato.ToListAsync());
        }

        // GET: Impiegati/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var impiegato = await _context.Impiegato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (impiegato == null)
            {
                return NotFound();
            }

            return View(impiegato);
        }

        // GET: Impiegati/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Impiegati/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ManagerId")] Impiegato impiegato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(impiegato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(impiegato);
        }

        // GET: Impiegati/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var impiegato = await _context.Impiegato.FindAsync(id);
            if (impiegato == null)
            {
                return NotFound();
            }
            return View(impiegato);
        }

        // POST: Impiegati/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ManagerId")] Impiegato impiegato)
        {
            if (id != impiegato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(impiegato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImpiegatoExists(impiegato.Id))
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
            return View(impiegato);
        }

        // GET: Impiegati/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var impiegato = await _context.Impiegato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (impiegato == null)
            {
                return NotFound();
            }

            return View(impiegato);
        }

        // POST: Impiegati/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var impiegato = await _context.Impiegato.FindAsync(id);
            if (impiegato != null)
            {
                _context.Impiegato.Remove(impiegato);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImpiegatoExists(int id)
        {
            return _context.Impiegato.Any(e => e.Id == id);
        }
    }
}
