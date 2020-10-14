using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheProgrammingInn.Com.Data;
using TheProgrammingInn.Com.Repository;

namespace TheProgrammingInn.Com.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly Context _context;

        public BlogController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(string title)
        {
            using(_context)
            {
                var blog = new BlogRepository(_context).GetByTitle(title);
                return View(blog);
            }
        }
    }
}
