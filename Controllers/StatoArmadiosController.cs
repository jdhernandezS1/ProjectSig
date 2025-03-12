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
    public class StatoArmadiosController : Controller
    {
        private readonly AppDbContext _context;

        public StatoArmadiosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: StatoArmadios
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatoArmadioModel.ToListAsync());
        }

        // GET: StatoArmadios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statoArmadioModel = await _context.StatoArmadioModel
                .FirstOrDefaultAsync(m => m.IdStatoArmadio == id);
            if (statoArmadioModel == null)
            {
                return NotFound();
            }

            return View(statoArmadioModel);
        }

        // GET: StatoArmadios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatoArmadios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStatoArmadio,StatoArmadio")] StatoArmadioModel statoArmadioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statoArmadioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statoArmadioModel);
        }

        // GET: StatoArmadios/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: StatoArmadios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdStatoArmadio,StatoArmadio")] StatoArmadioModel statoArmadioModel)
        {
            if (id != statoArmadioModel.IdStatoArmadio)
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
                    if (!StatoArmadioModelExists(statoArmadioModel.IdStatoArmadio))
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

        // GET: StatoArmadios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statoArmadioModel = await _context.StatoArmadioModel
                .FirstOrDefaultAsync(m => m.IdStatoArmadio == id);
            if (statoArmadioModel == null)
            {
                return NotFound();
            }

            return View(statoArmadioModel);
        }

        // POST: StatoArmadios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statoArmadioModel = await _context.StatoArmadioModel.FindAsync(id);
            if (statoArmadioModel != null)
            {
                _context.StatoArmadioModel.Remove(statoArmadioModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatoArmadioModelExists(int id)
        {
            return _context.StatoArmadioModel.Any(e => e.IdStatoArmadio == id);
        }
    }
}
