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
    public class DipartimentiController : Controller
    {
        private readonly AppDbContext _context;

        public DipartimentiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Dipartimenti
        public async Task<IActionResult> Index()
        {
            return View(await _context.DipartimentoModel.ToListAsync());
        }

        // GET: Dipartimenti/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dipartimentoModel = await _context.DipartimentoModel
                .FirstOrDefaultAsync(m => m.NomeDipartimento == id);
            if (dipartimentoModel == null)
            {
                return NotFound();
            }

            return View(dipartimentoModel);
        }

        // GET: Dipartimenti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dipartimenti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeDipartimento")] DipartimentoModel dipartimentoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dipartimentoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dipartimentoModel);
        }

        // GET: Dipartimenti/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dipartimentoModel = await _context.DipartimentoModel.FindAsync(id);
            if (dipartimentoModel == null)
            {
                return NotFound();
            }
            return View(dipartimentoModel);
        }

        // POST: Dipartimenti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NomeDipartimento")] DipartimentoModel dipartimentoModel)
        {
            if (id != dipartimentoModel.NomeDipartimento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dipartimentoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DipartimentoModelExists(dipartimentoModel.NomeDipartimento))
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
            return View(dipartimentoModel);
        }

        // GET: Dipartimenti/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dipartimentoModel = await _context.DipartimentoModel
                .FirstOrDefaultAsync(m => m.NomeDipartimento == id);
            if (dipartimentoModel == null)
            {
                return NotFound();
            }

            return View(dipartimentoModel);
        }

        // POST: Dipartimenti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var dipartimentoModel = await _context.DipartimentoModel.FindAsync(id);
            if (dipartimentoModel != null)
            {
                _context.DipartimentoModel.Remove(dipartimentoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DipartimentoModelExists(string id)
        {
            return _context.DipartimentoModel.Any(e => e.NomeDipartimento == id);
        }
    }
}
