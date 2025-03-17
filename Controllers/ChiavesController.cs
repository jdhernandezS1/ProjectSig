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
        private readonly AppDbContext _context;

        public ChiavesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Chiaves
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ChiaveModel.Include(c => c.ArmadioModel).Include(c => c.StatoChiaveModel);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Chiaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiaveModel = await _context.ChiaveModel
                .Include(c => c.ArmadioModel)
                .Include(c => c.StatoChiaveModel)
                .FirstOrDefaultAsync(m => m.IdChiave == id);
            if (chiaveModel == null)
            {
                return NotFound();
            }

            return View(chiaveModel);
        }

        // GET: Chiaves/Create
        public IActionResult Create()
        {
            ViewData["IdArmadio"] = new SelectList(_context.ArmadioModel, "IdArmadio", "IdArmadio");
            ViewData["IdStatoChiave"] = new SelectList(_context.StatoChiaveModel, "IdStatoChiave", "StatoChiave");
            return View();
        }

        // POST: Chiaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdChiave,IdArmadio,IdStatoChiave,DataModifica")] ChiaveModel chiaveModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiaveModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArmadio"] = new SelectList(_context.ArmadioModel, "IdArmadio", "IdArmadio", chiaveModel.IdArmadio);
            ViewData["IdStatoChiave"] = new SelectList(_context.StatoChiaveModel, "IdStatoChiave", "StatoChiave", chiaveModel.IdStatoChiave);
            return View(chiaveModel);
        }

        // GET: Chiaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiaveModel = await _context.ChiaveModel.FindAsync(id);
            if (chiaveModel == null)
            {
                return NotFound();
            }
            ViewData["IdArmadio"] = new SelectList(_context.ArmadioModel, "IdArmadio", "IdArmadio", chiaveModel.IdArmadio);
            ViewData["IdStatoChiave"] = new SelectList(_context.StatoChiaveModel, "IdStatoChiave", "StatoChiave", chiaveModel.IdStatoChiave);
            return View(chiaveModel);
        }

        // POST: Chiaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdChiave,IdArmadio,IdStatoChiave,DataModifica")] ChiaveModel chiaveModel)
        {
            if (id != chiaveModel.IdChiave)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiaveModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiaveModelExists(chiaveModel.IdChiave))
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
            ViewData["IdArmadio"] = new SelectList(_context.ArmadioModel, "IdArmadio", "IdArmadio", chiaveModel.IdArmadio);
            ViewData["IdStatoChiave"] = new SelectList(_context.StatoChiaveModel, "IdStatoChiave", "StatoChiave", chiaveModel.IdStatoChiave);
            return View(chiaveModel);
        }

        // GET: Chiaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiaveModel = await _context.ChiaveModel
                .Include(c => c.ArmadioModel)
                .Include(c => c.StatoChiaveModel)
                .FirstOrDefaultAsync(m => m.IdChiave == id);
            if (chiaveModel == null)
            {
                return NotFound();
            }

            return View(chiaveModel);
        }

        // POST: Chiaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiaveModel = await _context.ChiaveModel.FindAsync(id);
            if (chiaveModel != null)
            {
                _context.ChiaveModel.Remove(chiaveModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiaveModelExists(int id)
        {
            return _context.ChiaveModel.Any(e => e.IdChiave == id);
        }
    }
}
