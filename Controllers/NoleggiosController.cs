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
        public IActionResult Create()
        {
            ViewData["Idmobilio"] = new SelectList(_context.Mobilios, "Idmobilio", "Idmobilio");
            ViewData["Idpersona"] = new SelectList(_context.Personas, "Idpersona", "Cognome");
            return View();
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

                _context.Add(noleggio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idmobilio"] = new SelectList(_context.Mobilios, "Idmobilio", "Idmobilio", noleggio.Idmobilio);
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
    }
}
