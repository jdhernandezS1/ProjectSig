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
    public class CategoriaArmadiController : Controller
    {
        private readonly AppDbContext _context;

        public CategoriaArmadiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaArmadi
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaArmadioModel.ToListAsync());
        }

        // GET: CategoriaArmadi/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaArmadioModel = await _context.CategoriaArmadioModel
                .FirstOrDefaultAsync(m => m.CategoriaArmadio == id);
            if (categoriaArmadioModel == null)
            {
                return NotFound();
            }

            return View(categoriaArmadioModel);
        }

        // GET: CategoriaArmadi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaArmadi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaArmadio")] CategoriaArmadioModel categoriaArmadioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaArmadioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaArmadioModel);
        }

        // GET: CategoriaArmadi/Edit/5
        public async Task<IActionResult> Edit(string id)
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

        // POST: CategoriaArmadi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CategoriaArmadio")] CategoriaArmadioModel categoriaArmadioModel)
        {
            if (id != categoriaArmadioModel.CategoriaArmadio)
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
                    if (!CategoriaArmadioModelExists(categoriaArmadioModel.CategoriaArmadio))
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

        // GET: CategoriaArmadi/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaArmadioModel = await _context.CategoriaArmadioModel
                .FirstOrDefaultAsync(m => m.CategoriaArmadio == id);
            if (categoriaArmadioModel == null)
            {
                return NotFound();
            }

            return View(categoriaArmadioModel);
        }

        // POST: CategoriaArmadi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var categoriaArmadioModel = await _context.CategoriaArmadioModel.FindAsync(id);
            if (categoriaArmadioModel != null)
            {
                _context.CategoriaArmadioModel.Remove(categoriaArmadioModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaArmadioModelExists(string id)
        {
            return _context.CategoriaArmadioModel.Any(e => e.CategoriaArmadio == id);
        }
    }
}
