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
    public class TipoUtentesController : Controller
    {
        private readonly AppDbContext _context;

        public TipoUtentesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TipoUtentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoUtenteModel.ToListAsync());
        }

        // GET: TipoUtentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoUtenteModel = await _context.TipoUtenteModel
                .FirstOrDefaultAsync(m => m.IdTipoUtente == id);
            if (tipoUtenteModel == null)
            {
                return NotFound();
            }

            return View(tipoUtenteModel);
        }

        // GET: TipoUtentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoUtentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoUtente,TipoUtente")] TipoUtenteModel tipoUtenteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoUtenteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoUtenteModel);
        }

        // GET: TipoUtentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoUtenteModel = await _context.TipoUtenteModel.FindAsync(id);
            if (tipoUtenteModel == null)
            {
                return NotFound();
            }
            return View(tipoUtenteModel);
        }

        // POST: TipoUtentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoUtente,TipoUtente")] TipoUtenteModel tipoUtenteModel)
        {
            if (id != tipoUtenteModel.IdTipoUtente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoUtenteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoUtenteModelExists(tipoUtenteModel.IdTipoUtente))
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
            return View(tipoUtenteModel);
        }

        // GET: TipoUtentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoUtenteModel = await _context.TipoUtenteModel
                .FirstOrDefaultAsync(m => m.IdTipoUtente == id);
            if (tipoUtenteModel == null)
            {
                return NotFound();
            }

            return View(tipoUtenteModel);
        }

        // POST: TipoUtentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoUtenteModel = await _context.TipoUtenteModel.FindAsync(id);
            if (tipoUtenteModel != null)
            {
                _context.TipoUtenteModel.Remove(tipoUtenteModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoUtenteModelExists(int id)
        {
            return _context.TipoUtenteModel.Any(e => e.IdTipoUtente == id);
        }
    }
}
