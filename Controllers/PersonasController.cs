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
    public class PersonasController : Controller
    {
        private readonly PostgresContext _context;

        public PersonasController(PostgresContext context)
        {
            _context = context;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            var postgresContext = _context.Personas.Include(p => p.NomedipartimentoNavigation).Include(p => p.Tipopersonas);
            return View(await postgresContext.ToListAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.NomedipartimentoNavigation)
                .Include(p => p.Tipopersonas)
                .FirstOrDefaultAsync(m => m.Idpersona == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            ViewData["Dipartimento"] = new SelectList(_context.Dipartimentos, "Id", "Nomedipartimento");
            ViewData["Tipopersona"] = new SelectList(_context.Tipopersonas, "IdTiPersona", "Tipopersona1");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idpersona,Nome,Cognome,Email,Idmonitor,Tipopersona,Dipartimento")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Dipartimento"] = new SelectList(_context.Dipartimentos, "Id", "Nomedipartimento", persona.Dipartimento);
            ViewData["Tipopersona"] = new SelectList(_context.Tipopersonas, "IdTiPersona", "Tipopersona1", persona.Tipopersona);
            return View(persona);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            ViewData["Dipartimento"] = new SelectList(_context.Dipartimentos, "Id", "Nomedipartimento", persona.Dipartimento);
            ViewData["Tipopersona"] = new SelectList(_context.Tipopersonas, "IdTiPersona", "Tipopersona1", persona.Tipopersona);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idpersona,Nome,Cognome,Email,Idmonitor,Tipopersona,Dipartimento")] Persona persona)
        {
            if (id != persona.Idpersona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.Idpersona))
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
            ViewData["Dipartimento"] = new SelectList(_context.Dipartimentos, "Id", "Nomedipartimento", persona.Dipartimento);
            ViewData["Tipopersona"] = new SelectList(_context.Tipopersonas, "IdTiPersona", "Tipopersona1", persona.Tipopersona);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.NomedipartimentoNavigation)
                .Include(p => p.Tipopersonas)
                .FirstOrDefaultAsync(m => m.Idpersona == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.Idpersona == id);
        }
    }
}
