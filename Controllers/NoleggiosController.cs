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
            var postgresContext = _context.Noleggios.Include(n => n.IdmobilioNavigation).Include(n => n.IdpersonaNavigation);
            return View(await postgresContext.ToListAsync());
        }

        // GET: Noleggios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noleggio = await _context.Noleggios
                .Include(n => n.IdmobilioNavigation)
                .Include(n => n.IdpersonaNavigation)
                .FirstOrDefaultAsync(m => m.Idnoleggio == id);
            if (noleggio == null)
            {
                return NotFound();
            }

            return View(noleggio);
        }

        // GET: Noleggios/Create
        public IActionResult Create(int? id)
        {
            var mobiliosDisponibili = _context.Mobilios
                .Where(m => m.Statomobilio == 1)
                .ToList();

            // Si viene un id, lo seleccionamos
            ViewData["Idmobilio"] = new SelectList(mobiliosDisponibili, "Idmobilio", "Idmobilio", id);
            ViewData["Idpersona"] = new SelectList(_context.Personas, "Idpersona", "Cognome");

            var oggi = DateTime.Today;

            var modello = new Noleggio
            {
                Idmobilio = id ?? 0,
                Datainizio = oggi,
                Datafine = oggi.AddDays(1)
            };

            return View(modello);
        }


        // POST: Noleggios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idnoleggio,Datainizio,Datafine,Idmobilio,Idpersona,StatoAttivo")] Noleggio noleggio)
        {
            if (ModelState.IsValid)
            {
                noleggio.Datainizio = DateTime.SpecifyKind(noleggio.Datainizio, DateTimeKind.Utc);
                noleggio.Datafine = DateTime.SpecifyKind(noleggio.Datafine, DateTimeKind.Utc);

                var mobilio = await _context.Mobilios.FindAsync(noleggio.Idmobilio);
                if (mobilio == null)
                {
                    ModelState.AddModelError("", "Mobilio non trovato.");
                }
                else if (mobilio.Statomobilio != 1) // 1 = Disponibile
                {
                    ModelState.AddModelError("", "Il mobilio selezionato non è disponibile.");
                }
                else
                {
                    mobilio.Statomobilio = 2; // In uso
                    _context.Mobilios.Update(mobilio);

                    noleggio.StatoAttivo = StatoNoleggioEnum.Attivo; //  noleggio.StatoAttivo = 1;

                    _context.Noleggios.Add(noleggio);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewData["Idmobilio"] = new SelectList(_context.Mobilios.Where(m => m.Statomobilio == 1), "Idmobilio", "Idmobilio", noleggio.Idmobilio);
            ViewData["Idpersona"] = new SelectList(_context.Personas, "Idpersona", "Cognome", noleggio.Idpersona);
            return View(noleggio);
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
            ViewData["Idmobilio"] = new SelectList(_context.Mobilios, "Idmobilio", "Idmobilio", noleggio.Idmobilio);
            ViewData["Idpersona"] = new SelectList(_context.Personas, "Idpersona", "Cognome", noleggio.Idpersona);
            return View(noleggio);
        }

        // POST: Noleggios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idnoleggio,Datainizio,Datafine,Idmobilio,Idpersona,StatoAttivo")] Noleggio noleggio)
        {
            if (id != noleggio.Idnoleggio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    noleggio.Datainizio = DateTime.SpecifyKind(noleggio.Datainizio, DateTimeKind.Utc);
                    noleggio.Datafine = DateTime.SpecifyKind(noleggio.Datafine, DateTimeKind.Utc);

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
            ViewData["Idmobilio"] = new SelectList(_context.Mobilios, "Idmobilio", "Idmobilio", noleggio.Idmobilio);
            ViewData["Idpersona"] = new SelectList(_context.Personas, "Idpersona", "Cognome", noleggio.Idpersona);
            return View(noleggio);
        }

        // GET: Noleggios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noleggio = await _context.Noleggios
                .Include(n => n.IdmobilioNavigation)
                .Include(n => n.IdpersonaNavigation)
                .FirstOrDefaultAsync(m => m.Idnoleggio == id);
            if (noleggio == null)
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

        // GET: Scorta
        public async Task<IActionResult> Scorta(int page = 1)
        {
            var mobilios = await _context.Mobilios
                .Include(m => m.IdlocationNavigation)
                .Include(m => m.NumerochiaveNavigation)
                .Include(m => m.StatomobilioNavigation)
                .Include(m => m.TipomobilioNavigation)
                .ToListAsync();

            var mobilioConNoleggioList = new List<MobilioConNoleggioView>();

            foreach (var m in mobilios)
            {
                var noleggioAttivo = await _context.Noleggios
                    .FirstOrDefaultAsync(n => n.Idmobilio == m.Idmobilio && n.StatoAttivo == StatoNoleggioEnum.Attivo);

                mobilioConNoleggioList.Add(new MobilioConNoleggioView
                {
                    Mobilio = m,
                    NoleggioAttivoId = noleggioAttivo?.Idnoleggio
                });
            }

            var edifici = mobilioConNoleggioList
                .GroupBy(m => m.Mobilio.IdlocationNavigation.Stabile)
                .OrderBy(g => g.Key)
                .ToList();

            int totalEdifici = edifici.Count;
            var edificioCorrente = edifici.ElementAtOrDefault(page - 1);
            if (edificioCorrente == null)
                return NotFound();

            // 👇 Pasamos todos los nomi degli edifici
            ViewBag.Edifici = edifici.Select((g, index) => new { Nome = g.Key, Page = index + 1 }).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.Stabile = edificioCorrente.Key;

            return View(edificioCorrente.ToList());
        }
    }
}
