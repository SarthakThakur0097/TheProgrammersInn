using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheProgrammingInn.Com.Data;
using TheProgrammingInn.Com.Models;
using TheProgrammingInn.Com.Repository;
using TheProgrammingInn.Com.ViewModels;

namespace TheProgrammingInn.Com.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly Context _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminController(Context context, RoleManager<IdentityRole> roleManager,
                                                UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = userManager.Users;

            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };

                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if(result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";

                return View("NotFound");
            }

            var userClaims = await userManager.GetClaimsAsync(user);
            var userRoles = await userManager.GetRolesAsync(user);

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Claims = userClaims.Select(c => c.Value).ToList(),
                Roles = userRoles
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";

                return View("NotFound");
            }
            else
            {
                user.Email = model.Email;
                user.UserName = model.UserName;

                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }

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
