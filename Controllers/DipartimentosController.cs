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
    public class DipartimentosController : Controller
    {
        private readonly AppDbContext _context;

        public DipartimentosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Dipartimentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.DipartimentoModel.ToListAsync());
        }

        // GET: Dipartimentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dipartimentoModel = await _context.DipartimentoModel
                .FirstOrDefaultAsync(m => m.IdDipartimento == id);
            if (dipartimentoModel == null)
            {
                return NotFound();
            }

            return View(dipartimentoModel);
        }

        // GET: Dipartimentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dipartimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDipartimento,NomeDipartimento")] DipartimentoModel dipartimentoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dipartimentoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dipartimentoModel);
        }

        // GET: Dipartimentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: Dipartimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDipartimento,NomeDipartimento")] DipartimentoModel dipartimentoModel)
        {
            if (id != dipartimentoModel.IdDipartimento)
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
                    if (!DipartimentoModelExists(dipartimentoModel.IdDipartimento))
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

        // GET: Dipartimentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dipartimentoModel = await _context.DipartimentoModel
                .FirstOrDefaultAsync(m => m.IdDipartimento == id);
            if (dipartimentoModel == null)
            {
                return NotFound();
            }

            return View(dipartimentoModel);
        }

        // POST: Dipartimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dipartimentoModel = await _context.DipartimentoModel.FindAsync(id);
            if (dipartimentoModel != null)
            {
                _context.DipartimentoModel.Remove(dipartimentoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DipartimentoModelExists(int id)
        {
            return _context.DipartimentoModel.Any(e => e.IdDipartimento == id);
        }
    }
}
