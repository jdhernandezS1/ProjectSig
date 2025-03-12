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
    public class CategoriaArmadioController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriaArmadioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaArmadio
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaArmadioModel.ToListAsync());
        }

        // GET: CategoriaArmadio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaArmadioModel = await _context.CategoriaArmadioModel
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (categoriaArmadioModel == null)
            {
                return NotFound();
            }

            return View(categoriaArmadioModel);
        }

        // GET: CategoriaArmadio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaArmadio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoria,CategoriaArmadio")] CategoriaArmadioModel categoriaArmadioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaArmadioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaArmadioModel);
        }

        // GET: CategoriaArmadio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaArmadioModel = await _context.CategoriaArmadioModel.FindAsync(id);
            if (categoriaArmadioModel == null)
            {
                return NotFound();
            }
            return View(categoriaArmadioModel);
        }

        // POST: CategoriaArmadio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoria,CategoriaArmadio")] CategoriaArmadioModel categoriaArmadioModel)
        {
            if (id != categoriaArmadioModel.IdCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaArmadioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaArmadioModelExists(categoriaArmadioModel.IdCategoria))
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
            return View(categoriaArmadioModel);
        }

        // GET: CategoriaArmadio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaArmadioModel = await _context.CategoriaArmadioModel
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (categoriaArmadioModel == null)
            {
                return NotFound();
            }

            return View(categoriaArmadioModel);
        }

        // POST: CategoriaArmadio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaArmadioModel = await _context.CategoriaArmadioModel.FindAsync(id);
            if (categoriaArmadioModel != null)
            {
                _context.CategoriaArmadioModel.Remove(categoriaArmadioModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaArmadioModelExists(int id)
        {
            return _context.CategoriaArmadioModel.Any(e => e.IdCategoria == id);
        }
    }
}
