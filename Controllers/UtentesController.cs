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
    public class UtentesController : Controller
    {
        private readonly AppDbContext _context;

        public UtentesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Utentes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.UtenteModel_1.Include(u => u.DipartimentoModel).Include(u => u.TipoUtenteModel);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Utentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utenteModel = await _context.UtenteModel_1
                .Include(u => u.DipartimentoModel)
                .Include(u => u.TipoUtenteModel)
                .FirstOrDefaultAsync(m => m.IdUtente == id);
            if (utenteModel == null)
            {
                return NotFound();
            }

            return View(utenteModel);
        }

        // GET: Utentes/Create
        public IActionResult Create()
        {
            ViewData["IdDipartimento"] = new SelectList(_context.DipartimentoModel, "IdDipartimento", "NomeDipartimento");
            ViewData["IdTipoUtente"] = new SelectList(_context.TipoUtenteModel, "IdTipoUtente", "TipoUtente");
            return View();
        }

        // POST: Utentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUtente,Nome,Cognome,Email,IdMonitor,IdTipoUtente,IdDipartimento")] UtenteModel utenteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utenteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDipartimento"] = new SelectList(_context.DipartimentoModel, "IdDipartimento", "NomeDipartimento", utenteModel.IdDipartimento);
            ViewData["IdTipoUtente"] = new SelectList(_context.TipoUtenteModel, "IdTipoUtente", "TipoUtente", utenteModel.IdTipoUtente);
            return View(utenteModel);
        }

        // GET: Utentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utenteModel = await _context.UtenteModel_1.FindAsync(id);
            if (utenteModel == null)
            {
                return NotFound();
            }
            ViewData["IdDipartimento"] = new SelectList(_context.DipartimentoModel, "IdDipartimento", "NomeDipartimento", utenteModel.IdDipartimento);
            ViewData["IdTipoUtente"] = new SelectList(_context.TipoUtenteModel, "IdTipoUtente", "TipoUtente", utenteModel.IdTipoUtente);
            return View(utenteModel);
        }

        // POST: Utentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUtente,Nome,Cognome,Email,IdMonitor,IdTipoUtente,IdDipartimento")] UtenteModel utenteModel)
        {
            if (id != utenteModel.IdUtente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utenteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtenteModelExists(utenteModel.IdUtente))
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
            ViewData["IdDipartimento"] = new SelectList(_context.DipartimentoModel, "IdDipartimento", "NomeDipartimento", utenteModel.IdDipartimento);
            ViewData["IdTipoUtente"] = new SelectList(_context.TipoUtenteModel, "IdTipoUtente", "TipoUtente", utenteModel.IdTipoUtente);
            return View(utenteModel);
        }

        // GET: Utentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utenteModel = await _context.UtenteModel_1
                .Include(u => u.DipartimentoModel)
                .Include(u => u.TipoUtenteModel)
                .FirstOrDefaultAsync(m => m.IdUtente == id);
            if (utenteModel == null)
            {
                return NotFound();
            }

            return View(utenteModel);
        }

        // POST: Utentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utenteModel = await _context.UtenteModel_1.FindAsync(id);
            if (utenteModel != null)
            {
                _context.UtenteModel_1.Remove(utenteModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtenteModelExists(int id)
        {
            return _context.UtenteModel_1.Any(e => e.IdUtente == id);
        }
    }
}
