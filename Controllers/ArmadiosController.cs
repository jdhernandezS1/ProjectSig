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
    public class ArmadiosController : Controller
    {
        private readonly AppDbContext _context;

        public ArmadiosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Armadios
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ArmadioModel.Include(a => a.CategoriaArmadioModel).Include(a => a.LocationModel).Include(a => a.StatoArmadioModel);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Armadios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armadioModel = await _context.ArmadioModel
                .Include(a => a.CategoriaArmadioModel)
                .Include(a => a.LocationModel)
                .Include(a => a.StatoArmadioModel)
                .FirstOrDefaultAsync(m => m.IdArmadio == id);
            if (armadioModel == null)
            {
                return NotFound();
            }

            return View(armadioModel);
        }

        // GET: Armadios/Create
        public IActionResult Create()
        {
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaArmadioModel, "IdCategoria", "CategoriaArmadio");
            ViewData["IdLocation"] = new SelectList(_context.LocationModel, "IdLocation", "Stabile");
            ViewData["IdStatoArmadio"] = new SelectList(_context.StatoArmadioModel, "IdStatoArmadio", "StatoArmadio");
            return View();
        }

        // POST: Armadios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArmadio,IdLocation,Numero,StatoChiave,IdStatoArmadio,IdCategoria")] ArmadioModel armadioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(armadioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaArmadioModel, "IdCategoria", "CategoriaArmadio", armadioModel.IdCategoria);
            ViewData["IdLocation"] = new SelectList(_context.LocationModel, "IdLocation", "Stabile", armadioModel.IdLocation);
            ViewData["IdStatoArmadio"] = new SelectList(_context.StatoArmadioModel, "IdStatoArmadio", "StatoArmadio", armadioModel.IdStatoArmadio);
            return View(armadioModel);
        }

        // GET: Armadios/Edit/5
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
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaArmadioModel, "IdCategoria", "CategoriaArmadio", armadioModel.IdCategoria);
            ViewData["IdLocation"] = new SelectList(_context.LocationModel, "IdLocation", "Stabile", armadioModel.IdLocation);
            ViewData["IdStatoArmadio"] = new SelectList(_context.StatoArmadioModel, "IdStatoArmadio", "StatoArmadio", armadioModel.IdStatoArmadio);
            return View(armadioModel);
        }

        // POST: Armadios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArmadio,IdLocation,Numero,StatoChiave,IdStatoArmadio,IdCategoria")] ArmadioModel armadioModel)
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
            ViewData["IdCategoria"] = new SelectList(_context.CategoriaArmadioModel, "IdCategoria", "CategoriaArmadio", armadioModel.IdCategoria);
            ViewData["IdLocation"] = new SelectList(_context.LocationModel, "IdLocation", "Stabile", armadioModel.IdLocation);
            ViewData["IdStatoArmadio"] = new SelectList(_context.StatoArmadioModel, "IdStatoArmadio", "StatoArmadio", armadioModel.IdStatoArmadio);
            return View(armadioModel);
        }

        // GET: Armadios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var armadioModel = await _context.ArmadioModel
                .Include(a => a.CategoriaArmadioModel)
                .Include(a => a.LocationModel)
                .Include(a => a.StatoArmadioModel)
                .FirstOrDefaultAsync(m => m.IdArmadio == id);
            if (armadioModel == null)
            {
                return NotFound();
            }

            return View(armadioModel);
        }

        // POST: Armadios/Delete/5
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
