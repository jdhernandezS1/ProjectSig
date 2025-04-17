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
    public class MobiliosController : Controller
    {
        private readonly PostgresContext _context;

        public MobiliosController(PostgresContext context)
        {
            _context = context;
        }

        // GET: Mobilios
        public async Task<IActionResult> Index()
        {
            var postgresContext = _context.Mobilios.Include(m => m.IdlocationNavigation).Include(m => m.NumerochiaveNavigation).Include(m => m.StatomobilioNavigation).Include(m => m.TipomobilioNavigation);
            return View(await postgresContext.ToListAsync());
        }

        // GET: Mobilios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobilio = await _context.Mobilios
                .Include(m => m.IdlocationNavigation)
                .Include(m => m.NumerochiaveNavigation)
                .Include(m => m.StatomobilioNavigation)
                .Include(m => m.TipomobilioNavigation)
                .FirstOrDefaultAsync(m => m.Idmobilio == id);
            if (mobilio == null)
            {
                return NotFound();
            }

            return View(mobilio);
        }

        // GET: Mobilios/Create
        public IActionResult Create()
        {
            ViewData["Idlocation"] = new SelectList(_context.Locations, "Idlocation", "Piano");
            ViewData["Numerochiave"] = new SelectList(_context.Chiaves, "id", "id");
            ViewData["Statomobilio"] = new SelectList(_context.Statomobilios, "id", "Statomobilio1");
            ViewData["Tipomobilio"] = new SelectList(_context.Tipomobilios, "id", "Tipomobilio1");
            return View();
        }

        // POST: Mobilios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmobilio,Numero,Idlocation,Tipomobilio,Numerochiave,Statomobilio")] Mobilio mobilio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mobilio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idlocation"] = new SelectList(_context.Locations, "Idlocation", "Piano", mobilio.Idlocation);
            ViewData["Numerochiave"] = new SelectList(_context.Chiaves, "id", "id", mobilio.Numerochiave);
            ViewData["Statomobilio"] = new SelectList(_context.Statomobilios, "id", "Statomobilio1", mobilio.Statomobilio);
            ViewData["Tipomobilio"] = new SelectList(_context.Tipomobilios, "id", "Tipomobilio1", mobilio.Tipomobilio);
            return View(mobilio);
        }

        // GET: Mobilios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobilio = await _context.Mobilios.FindAsync(id);
            if (mobilio == null)
            {
                return NotFound();
            }
            ViewData["Idlocation"] = new SelectList(_context.Locations, "Idlocation", "Piano", mobilio.Idlocation);
            ViewData["Numerochiave"] = new SelectList(_context.Chiaves, "id", "id", mobilio.Numerochiave);
            ViewData["Statomobilio"] = new SelectList(_context.Statomobilios, "id", "Statomobilio1", mobilio.Statomobilio);
            ViewData["Tipomobilio"] = new SelectList(_context.Tipomobilios, "id", "Tipomobilio1", mobilio.Tipomobilio);
            return View(mobilio);
        }

        // POST: Mobilios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idmobilio,Numero,Idlocation,Tipomobilio,Numerochiave,Statomobilio")] Mobilio mobilio)
        {
            if (id != mobilio.Idmobilio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mobilio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MobilioExists(mobilio.Idmobilio))
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
            ViewData["Idlocation"] = new SelectList(_context.Locations, "Idlocation", "Piano", mobilio.Idlocation);
            ViewData["Numerochiave"] = new SelectList(_context.Chiaves, "id", "id", mobilio.Numerochiave);
            ViewData["Statomobilio"] = new SelectList(_context.Statomobilios, "id", "Statomobilio1", mobilio.Statomobilio);
            ViewData["Tipomobilio"] = new SelectList(_context.Tipomobilios, "id", "Tipomobilio1", mobilio.Tipomobilio);
            return View(mobilio);
        }

        // GET: Mobilios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobilio = await _context.Mobilios
                .Include(m => m.IdlocationNavigation)
                .Include(m => m.NumerochiaveNavigation)
                .Include(m => m.StatomobilioNavigation)
                .Include(m => m.TipomobilioNavigation)
                .FirstOrDefaultAsync(m => m.Idmobilio == id);
            if (mobilio == null)
            {
                return NotFound();
            }

            return View(mobilio);
        }

        // POST: Mobilios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mobilio = await _context.Mobilios.FindAsync(id);
            if (mobilio != null)
            {
                _context.Mobilios.Remove(mobilio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MobilioExists(int id)
        {
            return _context.Mobilios.Any(e => e.Idmobilio == id);
        }
    }
}
