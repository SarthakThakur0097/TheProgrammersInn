using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheProgrammingInn.Com.Data;
using TheProgrammingInn.Com.Models;
using TheProgrammingInn.Com.Repository;

namespace TheProgrammingInn.Com.Controllers
{
    public class AdminController : Controller
    {
        private readonly Context _context;
        public AdminController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditPage(string title)
        {
            if(title == null)
            {
                title = "test";
            }
            PagesRepository pagesRepository;
            
            using(_context)
            {
                pagesRepository  = new PagesRepository(_context);
                var page = pagesRepository.GetByTitle(title);

                if (page == null)
                {
                    page = new Page();
                    page.Title = title;

                    pagesRepository.Insert(page);

                }
                return View(page);
            }
        }

        [HttpPost]
        public IActionResult SavePage(string title, string content)
        {
            PagesRepository pagesRepository;

            using(_context)
            {
                pagesRepository = new PagesRepository(_context);

                var page = pagesRepository.GetByTitle(title);

                if(page == null)
                {
                    return View("Error");
                }

                page.Content = content;
                pagesRepository.Update(page);

                return RedirectToAction(nameof(Index));
            }
        }
    }
}
