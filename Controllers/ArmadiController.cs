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
    public class ArmadiController : Controller
    {
        private readonly AppDbContext _context;

        public ArmadiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Armadi
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ArmadioModel.Include(a => a.CategoriaArmadioModel).Include(a => a.StatoArmadioModel);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Armadi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armadioModel = await _context.ArmadioModel
                .Include(a => a.CategoriaArmadioModel)
                .Include(a => a.StatoArmadioModel)
                .FirstOrDefaultAsync(m => m.IdArmadio == id);
            if (armadioModel == null)
            {
                return NotFound();
            }

            return View(armadioModel);
        }

        // GET: Armadi/Create
        public IActionResult Create()
        {
            ViewData["CategoriaArmadio"] = new SelectList(_context.CategoriaArmadioModel, "CategoriaArmadio", "CategoriaArmadio");
            ViewData["StatoArmadio"] = new SelectList(_context.Set<StatoArmadioModel>(), "StatoArmadio", "StatoArmadio");
            return View();
        }

        // POST: Armadi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArmadio,Piano,Numero,StatoArmadio,CategoriaArmadio")] ArmadioModel armadioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(armadioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaArmadio"] = new SelectList(_context.CategoriaArmadioModel, "CategoriaArmadio", "CategoriaArmadio", armadioModel.CategoriaArmadio);
            ViewData["StatoArmadio"] = new SelectList(_context.Set<StatoArmadioModel>(), "StatoArmadio", "StatoArmadio", armadioModel.StatoArmadio);
            return View(armadioModel);
        }

        // GET: Armadi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armadioModel = await _context.ArmadioModel.FindAsync(id);
            if (armadioModel == null)
            {
                return NotFound();
            }
            ViewData["CategoriaArmadio"] = new SelectList(_context.CategoriaArmadioModel, "CategoriaArmadio", "CategoriaArmadio", armadioModel.CategoriaArmadio);
            ViewData["StatoArmadio"] = new SelectList(_context.Set<StatoArmadioModel>(), "StatoArmadio", "StatoArmadio", armadioModel.StatoArmadio);
            return View(armadioModel);
        }

        // POST: Armadi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArmadio,Piano,Numero,StatoArmadio,CategoriaArmadio")] ArmadioModel armadioModel)
        {
            if (id != armadioModel.IdArmadio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(armadioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmadioModelExists(armadioModel.IdArmadio))
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
            ViewData["CategoriaArmadio"] = new SelectList(_context.CategoriaArmadioModel, "CategoriaArmadio", "CategoriaArmadio", armadioModel.CategoriaArmadio);
            ViewData["StatoArmadio"] = new SelectList(_context.Set<StatoArmadioModel>(), "StatoArmadio", "StatoArmadio", armadioModel.StatoArmadio);
            return View(armadioModel);
        }

        // GET: Armadi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armadioModel = await _context.ArmadioModel
                .Include(a => a.CategoriaArmadioModel)
                .Include(a => a.StatoArmadioModel)
                .FirstOrDefaultAsync(m => m.IdArmadio == id);
            if (armadioModel == null)
            {
                return NotFound();
            }

            return View(armadioModel);
        }

        // POST: Armadi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var armadioModel = await _context.ArmadioModel.FindAsync(id);
            if (armadioModel != null)
            {
                _context.ArmadioModel.Remove(armadioModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArmadioModelExists(int id)
        {
            return _context.ArmadioModel.Any(e => e.IdArmadio == id);
        }
    }
}
