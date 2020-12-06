using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectBandits.Models;
using FinalProjectBandits.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectBandits.Controllers
{

        public class StickyRegistrationController : Controller
        {

            private readonly IStickyService _stickyService;
            public StickyRegistrationController(IStickyService stickyService)
            {
                _stickyService = stickyService;
            }

            [HttpGet]
            public IActionResult Index()
            {
                return View();
            }

            [HttpPost]
            public IActionResult StickyResultView(StickyRegistrationViewModel stickyRegistrationViewModel)
            {
                var result = _stickyService.Sticky(stickyRegistrationViewModel);

                return View(result);
            }
        }
    }