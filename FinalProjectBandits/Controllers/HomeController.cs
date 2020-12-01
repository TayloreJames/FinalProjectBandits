using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinalProjectBandits.Models;
using Microsoft.EntityFrameworkCore;
using FinalProjectBandits.Data;

namespace FinalProjectBandits.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        public HomeController(ApplicationDbContext applicationDbContext, ILogger<HomeController> logger)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var Customers = await _applicationDbContext.Customers.ToListAsync();
            return View();
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
