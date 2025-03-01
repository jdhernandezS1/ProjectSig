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
    public class StatoArmadiController : Controller
    {
        private readonly AppDbContext _context;

        public StatoArmadiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StatoArmadi
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatoArmadioModel.ToListAsync());
        }

        // GET: StatoArmadi/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statoArmadioModel = await _context.StatoArmadioModel
                .FirstOrDefaultAsync(m => m.StatoArmadio == id);
            if (statoArmadioModel == null)
            {
                return NotFound();
            }

            return View(statoArmadioModel);
        }

        // GET: StatoArmadi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatoArmadi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatoArmadio")] StatoArmadioModel statoArmadioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statoArmadioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statoArmadioModel);
        }

        // GET: StatoArmadi/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statoArmadioModel = await _context.StatoArmadioModel.FindAsync(id);
            if (statoArmadioModel == null)
            {
                return NotFound();
            }
            return View(statoArmadioModel);
        }

        // POST: StatoArmadi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StatoArmadio")] StatoArmadioModel statoArmadioModel)
        {
            if (id != statoArmadioModel.StatoArmadio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statoArmadioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatoArmadioModelExists(statoArmadioModel.StatoArmadio))
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
            return View(statoArmadioModel);
        }

        // GET: StatoArmadi/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statoArmadioModel = await _context.StatoArmadioModel
                .FirstOrDefaultAsync(m => m.StatoArmadio == id);
            if (statoArmadioModel == null)
            {
                return NotFound();
            }

            return View(statoArmadioModel);
        }

        // POST: StatoArmadi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var statoArmadioModel = await _context.StatoArmadioModel.FindAsync(id);
            if (statoArmadioModel != null)
            {
                _context.StatoArmadioModel.Remove(statoArmadioModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatoArmadioModelExists(string id)
        {
            return _context.StatoArmadioModel.Any(e => e.StatoArmadio == id);
        }
    }
}
