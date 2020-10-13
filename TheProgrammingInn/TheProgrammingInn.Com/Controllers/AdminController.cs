using System.IO;
using Microsoft.AspNetCore.Mvc;
using TheProgrammingInn.Com.Data;
using TheProgrammingInn.Com.Models;
using TheProgrammingInn.Com.Repository;
using TheProgrammingInn.Com.ViewModels;

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
        public IActionResult CreateBlog()
        {
            CreateBlogViewModel page = new CreateBlogViewModel();
            return View(page);
        }
        [HttpPost]
        public IActionResult CreateBlog(CreateBlogViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                BlogRepository pagesRepository;
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

                    pagesRepository = new BlogRepository(_context);

                    var page = pagesRepository.GetByTitle(viewModel.Title);

                    if (page == null)
                    {
                        Blog newPage = new Blog(viewModel.Title, viewModel.Description, viewModel.Content, img);
                        pagesRepository.Insert(newPage);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View(viewModel);
        }

        public IActionResult EditPage(string title)
        {
            if(title == null)
            {
                title = "test";
            }
            BlogRepository pagesRepository;
            
            using(_context)
            {
                pagesRepository  = new BlogRepository(_context);
                var page = pagesRepository.GetByTitle(title);

                if (page == null)
                {
                    page = new Blog();
                    page.Title = title;

                    pagesRepository.Insert(page);

                }
                return View(page);
            }
        }

        [HttpPost]
        public IActionResult SavePage(string title, string content)
        {
            BlogRepository pagesRepository;

            using(_context)
            {
                pagesRepository = new BlogRepository(_context);

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
