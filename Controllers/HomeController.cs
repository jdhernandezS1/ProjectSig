using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using armadieti2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace armadieti2.Controllers
{
    public class HomeController : Controller
    {
        private readonly PostgresContext _context;

        public HomeController(PostgresContext context)
        {
            _context = context;
        }

        // GET: home
        public async Task<IActionResult> Index()
        {
            var mobilios = await _context.Mobilios
                .Include(m => m.IdlocationNavigation)
                .Include(m => m.NumerochiaveNavigation)
                .Include(m => m.StatomobilioNavigation)
                .Include(m => m.TipomobilioNavigation)
                .ToListAsync();

            var result = new List<MobilioConNoleggioView>();

            foreach (var mobilio in mobilios)
            {
                var noleggioAttivo = await _context.Noleggios
                    .FirstOrDefaultAsync(n => n.Idmobilio == mobilio.Idmobilio && n.StatoAttivo == StatoNoleggioEnum.Attivo);

                result.Add(new MobilioConNoleggioView
                {
                    Mobilio = mobilio,
                    NoleggioAttivoId = noleggioAttivo?.Idnoleggio
                });
            }

            return View(result);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
