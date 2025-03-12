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
    public class StatoChiavesController : Controller
    {
        private readonly AppDbContext _context;

        public StatoChiavesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StatoChiaves
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatoChiaveModel.ToListAsync());
        }

        // GET: StatoChiaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statoChiaveModel = await _context.StatoChiaveModel
                .FirstOrDefaultAsync(m => m.IdStatoChiave == id);
            if (statoChiaveModel == null)
            {
                return NotFound();
            }

            return View(statoChiaveModel);
        }

        // GET: StatoChiaves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatoChiaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStatoChiave,StatoChiave")] StatoChiaveModel statoChiaveModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statoChiaveModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statoChiaveModel);
        }

        // GET: StatoChiaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: StatoChiaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStatoChiave,StatoChiave")] StatoChiaveModel statoChiaveModel)
        {
            if (id != statoChiaveModel.IdStatoChiave)
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
                    if (!StatoChiaveModelExists(statoChiaveModel.IdStatoChiave))
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

        // GET: StatoChiaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statoChiaveModel = await _context.StatoChiaveModel
                .FirstOrDefaultAsync(m => m.IdStatoChiave == id);
            if (statoChiaveModel == null)
            {
                return NotFound();
            }

            return View(statoChiaveModel);
        }

        // POST: StatoChiaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statoChiaveModel = await _context.StatoChiaveModel.FindAsync(id);
            if (statoChiaveModel != null)
            {
                _context.StatoChiaveModel.Remove(statoChiaveModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatoChiaveModelExists(int id)
        {
            return _context.StatoChiaveModel.Any(e => e.IdStatoChiave == id);
        }
    }
}
