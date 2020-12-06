using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinalProjectBandits.Models;
using Microsoft.EntityFrameworkCore;
using FinalProjectBandits.Data;
using System.Collections.Generic;
using System.Linq;

namespace FinalProjectBandits.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly int NUMBEROFITEM = 10;

        public HomeController(ApplicationDbContext applicationDbContext, ILogger<HomeController> logger)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var taskListItems = await _applicationDbContext.TaskListItems
                .OrderBy(item => item.DatePosted)
                .Take(10).ToListAsync();
            return View(taskListItems);

            /*List<TaskListItem> top10item = FakeDataSeed
                    .GetTaskListItems()
                    .OrderBy(item => item.DatePosted)
                    .Take<TaskListItem>(NUMBEROFITEM)
                    .ToList<TaskListItem>();
            return View(top10item);
        */
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskListItem item = null;
            item = await _applicationDbContext.TaskListItems.FirstOrDefaultAsync(item => item.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            // foreach (TaskListItem aitem in FakeDataSeed.GetTaskListItems())
            //{
            //     if (aitem.Id == id) 
            //     {
            //         item = aitem;
            //        break;
            //    }

            // }
            return View(item);
        }


        //public IActionResult MuapFeatureMap()
        // {
        //    return View();
        //}

        public IActionResult About()
        {
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
