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
        private readonly PostgresContext _context;

        public NoleggiosController(PostgresContext context)
        {
            _context = context;
        }

        // GET: Noleggios
        public async Task<IActionResult> Index()
        {
<<<<<<< HEAD
            var postgresContext = _context.Noleggios.Include(n => n.IdmobilioNavigation).Include(n => n.IdpersonaNavigation);
            return View(await postgresContext.ToListAsync());
=======
            var appDbContext = _context.NoleggioModel.Include(n => n.ArmadioModel).Include(n => n.TipoPagamentoModel).Include(n => n.UtenteModel);
            return View(await appDbContext.ToListAsync());
>>>>>>> 2036f1c701d93c19b379b0a54ff893de8c5f3de4
        }

        // GET: Noleggios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

<<<<<<< HEAD
            var noleggio = await _context.Noleggios
                .Include(n => n.IdmobilioNavigation)
                .Include(n => n.IdpersonaNavigation)
                .FirstOrDefaultAsync(m => m.Idnoleggio == id);
            if (noleggio == null)
=======
            var noleggioModel = await _context.NoleggioModel
                .Include(n => n.ArmadioModel)
                .Include(n => n.TipoPagamentoModel)
                .Include(n => n.UtenteModel)
                .FirstOrDefaultAsync(m => m.IdNoleggio == id);
            if (noleggioModel == null)
>>>>>>> 2036f1c701d93c19b379b0a54ff893de8c5f3de4
            {
                return NotFound();
            }

            return View(noleggio);
        }

        // GET: Noleggios/Create
        public IActionResult Create()
        {
<<<<<<< HEAD
            ViewData["Idmobilio"] = new SelectList(_context.Mobilios, "Idmobilio", "Idmobilio");
            ViewData["Idpersona"] = new SelectList(_context.Personas, "Idpersona", "Idpersona");
=======
            ViewData["IdArmadio"] = new SelectList(_context.ArmadioModel, "IdArmadio", "IdArmadio");
            ViewData["Numero"] = new SelectList(_context.ArmadioModel, "Numero");
            ViewData["IdTipoPagamento"] = new SelectList(_context.TipoPagamentoModel, "IdTipoPagamento", "Pagamento");
            ViewData["IdUtente"] = new SelectList(_context.UtenteModel_1, "IdUtente", "Cognome");
>>>>>>> 2036f1c701d93c19b379b0a54ff893de8c5f3de4
            return View();
        }

        // POST: Noleggios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public async Task<IActionResult> Create([Bind("Idnoleggio,Datainizio,Datafine,Idmobilio,Idpersona,Attivo")] Noleggio noleggio)
=======
        public async Task<IActionResult> Create([Bind("IdNoleggio,DataInizio,DataFine,IdTipoPagamento,Cauzione,IdArmadio,IdUtente")] NoleggioModel noleggioModel)
>>>>>>> 2036f1c701d93c19b379b0a54ff893de8c5f3de4
        {
            if (ModelState.IsValid)
            {
                _context.Add(noleggio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
<<<<<<< HEAD
            ViewData["Idmobilio"] = new SelectList(_context.Mobilios, "Idmobilio", "Idmobilio", noleggio.Idmobilio);
            ViewData["Idpersona"] = new SelectList(_context.Personas, "Idpersona", "Idpersona", noleggio.Idpersona);
            return View(noleggio);
=======
            ViewData["IdArmadio"] = new SelectList(_context.ArmadioModel, "IdArmadio", "IdArmadio", noleggioModel.IdArmadio);
            ViewData["IdTipoPagamento"] = new SelectList(_context.TipoPagamentoModel, "IdTipoPagamento", "Pagamento", noleggioModel.IdTipoPagamento);
            ViewData["IdUtente"] = new SelectList(_context.UtenteModel_1, "IdUtente", "Cognome", noleggioModel.IdUtente);
            return View(noleggioModel);
>>>>>>> 2036f1c701d93c19b379b0a54ff893de8c5f3de4
        }

        // GET: Noleggios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noleggio = await _context.Noleggios.FindAsync(id);
            if (noleggio == null)
            {
                return NotFound();
            }
<<<<<<< HEAD
            ViewData["Idmobilio"] = new SelectList(_context.Mobilios, "Idmobilio", "Idmobilio", noleggio.Idmobilio);
            ViewData["Idpersona"] = new SelectList(_context.Personas, "Idpersona", "Idpersona", noleggio.Idpersona);
            return View(noleggio);
=======
            ViewData["IdArmadio"] = new SelectList(_context.ArmadioModel, "IdArmadio", "IdArmadio", noleggioModel.IdArmadio);
            ViewData["IdTipoPagamento"] = new SelectList(_context.TipoPagamentoModel, "IdTipoPagamento", "Pagamento", noleggioModel.IdTipoPagamento);
            ViewData["IdUtente"] = new SelectList(_context.UtenteModel_1, "IdUtente", "Cognome", noleggioModel.IdUtente);
            return View(noleggioModel);
>>>>>>> 2036f1c701d93c19b379b0a54ff893de8c5f3de4
        }

        // POST: Noleggios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
<<<<<<< HEAD
        public async Task<IActionResult> Edit(int id, [Bind("Idnoleggio,Datainizio,Datafine,Idmobilio,Idpersona,Attivo")] Noleggio noleggio)
=======
        public async Task<IActionResult> Edit(int id, [Bind("IdNoleggio,DataInizio,DataFine,IdTipoPagamento,Cauzione,IdArmadio,IdUtente")] NoleggioModel noleggioModel)
>>>>>>> 2036f1c701d93c19b379b0a54ff893de8c5f3de4
        {
            if (id != noleggio.Idnoleggio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(noleggio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoleggioExists(noleggio.Idnoleggio))
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
<<<<<<< HEAD
            ViewData["Idmobilio"] = new SelectList(_context.Mobilios, "Idmobilio", "Idmobilio", noleggio.Idmobilio);
            ViewData["Idpersona"] = new SelectList(_context.Personas, "Idpersona", "Idpersona", noleggio.Idpersona);
            return View(noleggio);
=======
            ViewData["IdArmadio"] = new SelectList(_context.ArmadioModel, "IdArmadio", "IdArmadio", noleggioModel.IdArmadio);
            ViewData["IdTipoPagamento"] = new SelectList(_context.TipoPagamentoModel, "IdTipoPagamento", "Pagamento", noleggioModel.IdTipoPagamento);
            ViewData["IdUtente"] = new SelectList(_context.UtenteModel_1, "IdUtente", "Cognome", noleggioModel.IdUtente);
            return View(noleggioModel);
>>>>>>> 2036f1c701d93c19b379b0a54ff893de8c5f3de4
        }

        // GET: Noleggios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

<<<<<<< HEAD
            var noleggio = await _context.Noleggios
                .Include(n => n.IdmobilioNavigation)
                .Include(n => n.IdpersonaNavigation)
                .FirstOrDefaultAsync(m => m.Idnoleggio == id);
            if (noleggio == null)
=======
            var noleggioModel = await _context.NoleggioModel
                .Include(n => n.ArmadioModel)
                .Include(n => n.TipoPagamentoModel)
                .Include(n => n.UtenteModel)
                .FirstOrDefaultAsync(m => m.IdNoleggio == id);
            if (noleggioModel == null)
>>>>>>> 2036f1c701d93c19b379b0a54ff893de8c5f3de4
            {
                return NotFound();
            }

            return View(noleggio);
        }

        // POST: Noleggios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var noleggio = await _context.Noleggios.FindAsync(id);
            if (noleggio != null)
            {
                _context.Noleggios.Remove(noleggio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoleggioExists(int id)
        {
            return _context.Noleggios.Any(e => e.Idnoleggio == id);
        }
    }
}
