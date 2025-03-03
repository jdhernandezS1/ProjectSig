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
    public class StatoChiaviController : Controller
    {
        private readonly AppDbContext _context;

        public StatoChiaviController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StatoChiavi
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatoChiaveModel.ToListAsync());
        }

        // GET: StatoChiavi/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statoChiaveModel = await _context.StatoChiaveModel
                .FirstOrDefaultAsync(m => m.StatoChiave == id);
            if (statoChiaveModel == null)
            {
                return NotFound();
            }

            return View(statoChiaveModel);
        }

        // GET: StatoChiavi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatoChiavi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatoChiave")] StatoChiaveModel statoChiaveModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statoChiaveModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statoChiaveModel);
        }

        // GET: StatoChiavi/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statoChiaveModel = await _context.StatoChiaveModel.FindAsync(id);
            if (statoChiaveModel == null)
            {
                return NotFound();
            }
            return View(statoChiaveModel);
        }

        // POST: StatoChiavi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StatoChiave")] StatoChiaveModel statoChiaveModel)
        {
            if (id != statoChiaveModel.StatoChiave)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statoChiaveModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatoChiaveModelExists(statoChiaveModel.StatoChiave))
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
            return View(statoChiaveModel);
        }

        // GET: StatoChiavi/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statoChiaveModel = await _context.StatoChiaveModel
                .FirstOrDefaultAsync(m => m.StatoChiave == id);
            if (statoChiaveModel == null)
            {
                return NotFound();
            }

            return View(statoChiaveModel);
        }

        // POST: StatoChiavi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var statoChiaveModel = await _context.StatoChiaveModel.FindAsync(id);
            if (statoChiaveModel != null)
            {
                _context.StatoChiaveModel.Remove(statoChiaveModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatoChiaveModelExists(string id)
        {
            return _context.StatoChiaveModel.Any(e => e.StatoChiave == id);
        }
    }
}
