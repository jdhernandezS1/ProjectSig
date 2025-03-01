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
    public class TipoUtentiController : Controller
    {
        private readonly AppDbContext _context;

        public TipoUtentiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TipoUtenti
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoUtenteModel.ToListAsync());
        }

        // GET: TipoUtenti/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoUtenteModel = await _context.TipoUtenteModel
                .FirstOrDefaultAsync(m => m.TipoUtente == id);
            if (tipoUtenteModel == null)
            {
                return NotFound();
            }

            return View(tipoUtenteModel);
        }

        // GET: TipoUtenti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoUtenti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoUtente")] TipoUtenteModel tipoUtenteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoUtenteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoUtenteModel);
        }

        // GET: TipoUtenti/Edit/5
        public async Task<IActionResult> Edit(string id)
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

        // POST: TipoUtenti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TipoUtente")] TipoUtenteModel tipoUtenteModel)
        {
            if (id != tipoUtenteModel.TipoUtente)
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
                    if (!TipoUtenteModelExists(tipoUtenteModel.TipoUtente))
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

        // GET: TipoUtenti/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoUtenteModel = await _context.TipoUtenteModel
                .FirstOrDefaultAsync(m => m.TipoUtente == id);
            if (tipoUtenteModel == null)
            {
                return NotFound();
            }

            return View(tipoUtenteModel);
        }

        // POST: TipoUtenti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tipoUtenteModel = await _context.TipoUtenteModel.FindAsync(id);
            if (tipoUtenteModel != null)
            {
                _context.TipoUtenteModel.Remove(tipoUtenteModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoUtenteModelExists(string id)
        {
            return _context.TipoUtenteModel.Any(e => e.TipoUtente == id);
        }
    }
}
