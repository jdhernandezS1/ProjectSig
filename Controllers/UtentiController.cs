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
    public class UtentiController : Controller
    {
        private readonly AppDbContext _context;

        public UtentiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Utenti
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.UtenteModel_1.Include(u => u.DipartimentoModel).Include(u => u.TipoUtenteModel);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Utenti/Details/5
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

        // GET: Utenti/Create
        public IActionResult Create()
        {
            ViewData["NomeDipartimento"] = new SelectList(_context.DipartimentoModel, "NomeDipartimento", "NomeDipartimento");
            ViewData["TipoUtente"] = new SelectList(_context.TipoUtenteModel, "TipoUtente", "TipoUtente");
            return View();
        }

        // POST: Utenti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUtente,Nome,Cognome,Email,IdMonitor,TipoUtente,NomeDipartimento")] UtenteModel utenteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utenteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NomeDipartimento"] = new SelectList(_context.DipartimentoModel, "NomeDipartimento", "NomeDipartimento", utenteModel.NomeDipartimento);
            ViewData["TipoUtente"] = new SelectList(_context.TipoUtenteModel, "TipoUtente", "TipoUtente", utenteModel.TipoUtente);
            return View(utenteModel);
        }

        // GET: Utenti/Edit/5
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
            ViewData["NomeDipartimento"] = new SelectList(_context.DipartimentoModel, "NomeDipartimento", "NomeDipartimento", utenteModel.NomeDipartimento);
            ViewData["TipoUtente"] = new SelectList(_context.TipoUtenteModel, "TipoUtente", "TipoUtente", utenteModel.TipoUtente);
            return View(utenteModel);
        }

        // POST: Utenti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUtente,Nome,Cognome,Email,IdMonitor,TipoUtente,NomeDipartimento")] UtenteModel utenteModel)
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
            ViewData["NomeDipartimento"] = new SelectList(_context.DipartimentoModel, "NomeDipartimento", "NomeDipartimento", utenteModel.NomeDipartimento);
            ViewData["TipoUtente"] = new SelectList(_context.TipoUtenteModel, "TipoUtente", "TipoUtente", utenteModel.TipoUtente);
            return View(utenteModel);
        }

        // GET: Utenti/Delete/5
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

        // POST: Utenti/Delete/5
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
