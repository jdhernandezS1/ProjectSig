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
    public class NoleggiosController : Controller
    {
        private readonly AppDbContext _context;

        public NoleggiosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Noleggios
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.NoleggioModel.Include(n => n.ArmadioModel).Include(n => n.ChiaveModel).Include(n => n.TipoPagamentoModel).Include(n => n.UtenteModel);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Noleggios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noleggioModel = await _context.NoleggioModel
                .Include(n => n.ArmadioModel)
                .Include(n => n.ChiaveModel)
                .Include(n => n.TipoPagamentoModel)
                .Include(n => n.UtenteModel)
                .FirstOrDefaultAsync(m => m.IdNoleggio == id);
            if (noleggioModel == null)
            {
                return NotFound();
            }

            return View(noleggioModel);
        }

        // GET: Noleggios/Create
        public IActionResult Create()
        {
            ViewData["IdArmadio"] = new SelectList(_context.ArmadioModel, "IdArmadio", "Piano");
            ViewData["IdChiave"] = new SelectList(_context.ChiaveModel, "IdChiave", "IdChiave");
            ViewData["IdTipoPagamento"] = new SelectList(_context.TipoPagamentoModel, "IdTipoPagamento", "Pagamento");
            ViewData["IdUtente"] = new SelectList(_context.UtenteModel_1, "IdUtente", "Cognome");
            return View();
        }

        // POST: Noleggios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNoleggio,DataInizio,DataFine,IdTipoPagamento,Cauzione,IdArmadio,IdChiave,IdUtente")] NoleggioModel noleggioModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(noleggioModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArmadio"] = new SelectList(_context.ArmadioModel, "IdArmadio", "Piano", noleggioModel.IdArmadio);
            ViewData["IdChiave"] = new SelectList(_context.ChiaveModel, "IdChiave", "IdChiave", noleggioModel.IdChiave);
            ViewData["IdTipoPagamento"] = new SelectList(_context.TipoPagamentoModel, "IdTipoPagamento", "Pagamento", noleggioModel.IdTipoPagamento);
            ViewData["IdUtente"] = new SelectList(_context.UtenteModel_1, "IdUtente", "Cognome", noleggioModel.IdUtente);
            return View(noleggioModel);
        }

        // GET: Noleggios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noleggioModel = await _context.NoleggioModel.FindAsync(id);
            if (noleggioModel == null)
            {
                return NotFound();
            }
            ViewData["IdArmadio"] = new SelectList(_context.ArmadioModel, "IdArmadio", "Piano", noleggioModel.IdArmadio);
            ViewData["IdChiave"] = new SelectList(_context.ChiaveModel, "IdChiave", "IdChiave", noleggioModel.IdChiave);
            ViewData["IdTipoPagamento"] = new SelectList(_context.TipoPagamentoModel, "IdTipoPagamento", "Pagamento", noleggioModel.IdTipoPagamento);
            ViewData["IdUtente"] = new SelectList(_context.UtenteModel_1, "IdUtente", "Cognome", noleggioModel.IdUtente);
            return View(noleggioModel);
        }

        // POST: Noleggios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNoleggio,DataInizio,DataFine,IdTipoPagamento,Cauzione,IdArmadio,IdChiave,IdUtente")] NoleggioModel noleggioModel)
        {
            if (id != noleggioModel.IdNoleggio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noleggioModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoleggioModelExists(noleggioModel.IdNoleggio))
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
            ViewData["IdArmadio"] = new SelectList(_context.ArmadioModel, "IdArmadio", "Piano", noleggioModel.IdArmadio);
            ViewData["IdChiave"] = new SelectList(_context.ChiaveModel, "IdChiave", "IdChiave", noleggioModel.IdChiave);
            ViewData["IdTipoPagamento"] = new SelectList(_context.TipoPagamentoModel, "IdTipoPagamento", "Pagamento", noleggioModel.IdTipoPagamento);
            ViewData["IdUtente"] = new SelectList(_context.UtenteModel_1, "IdUtente", "Cognome", noleggioModel.IdUtente);
            return View(noleggioModel);
        }

        // GET: Noleggios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noleggioModel = await _context.NoleggioModel
                .Include(n => n.ArmadioModel)
                .Include(n => n.ChiaveModel)
                .Include(n => n.TipoPagamentoModel)
                .Include(n => n.UtenteModel)
                .FirstOrDefaultAsync(m => m.IdNoleggio == id);
            if (noleggioModel == null)
            {
                return NotFound();
            }

            return View(noleggioModel);
        }

        // POST: Noleggios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noleggioModel = await _context.NoleggioModel.FindAsync(id);
            if (noleggioModel != null)
            {
                _context.NoleggioModel.Remove(noleggioModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoleggioModelExists(int id)
        {
            return _context.NoleggioModel.Any(e => e.IdNoleggio == id);
        }
    }
}
