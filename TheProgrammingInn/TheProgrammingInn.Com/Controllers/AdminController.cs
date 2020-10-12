using System;
using System.Collections.Generic;
using System.IO;
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
        [HttpGet]
        public IActionResult AddPage()
        {
            Page page = new Page();
            return View(page);
        }
        [HttpPost]
        public IActionResult AddPage(string title, string content)
        {
            PagesRepository pagesRepository;
            using (_context)
            {
                Image img = new Image(); ;
                foreach (var file in Request.Form.Files)
                {
                    img.ImageTitle = file.FileName;

                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    img.ImageData = ms.ToArray();

                    ms.Close();
                    ms.Dispose();
                }

                pagesRepository = new PagesRepository(_context);

                var page = pagesRepository.GetByTitle(title);

                if (page == null)
                {
                    Page newPage = new Page();
                    newPage.Title = title;
                    newPage.Content = content;
                    newPage.DispalyImage = img;

                    pagesRepository.Insert(newPage);
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
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
