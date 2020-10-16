using Microsoft.AspNetCore.Mvc;

namespace TheProgrammingInn.Com.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
