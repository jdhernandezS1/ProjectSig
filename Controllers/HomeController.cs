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
<<<<<<< HEAD
        private readonly PostgresContext _context;

        public HomeController(PostgresContext context)
=======
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
>>>>>>> 2036f1c701d93c19b379b0a54ff893de8c5f3de4
        {
            _context = context;
        }

        // GET: home
        public async Task<IActionResult> Index()
        {
<<<<<<< HEAD
            //var appDbContext = _context.ArmadioModel.Include(a => a.LocationModel).Include(a => a.StatoArmadioModel);
            //return View(await appDbContext.ToListAsync());
            return View();

=======
            var appDbContext = _context.ArmadioModel.Include(a => a.LocationModel).Include(a => a.StatoArmadioModel);
            return View(await appDbContext.ToListAsync());            
>>>>>>> 2036f1c701d93c19b379b0a54ff893de8c5f3de4
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
