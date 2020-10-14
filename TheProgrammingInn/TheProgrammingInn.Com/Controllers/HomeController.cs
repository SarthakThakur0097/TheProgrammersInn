using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheProgrammingInn.Com.Data;
using TheProgrammingInn.Com.Models;
using TheProgrammingInn.Com.Repository;
using TheProgrammingInn.Com.ViewModels;

namespace TheProgrammingInn.Com.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;

        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            BlogRepository pagesRepository;

            using(_context)
            {
                pagesRepository = new BlogRepository(_context);
                var pages = pagesRepository.GetAllPages();
                return View(pages);
            }
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
