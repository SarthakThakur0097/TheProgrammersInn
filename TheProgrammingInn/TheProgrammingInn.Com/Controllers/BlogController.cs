using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TheProgrammingInn.Com.Data;
using TheProgrammingInn.Com.Models;
using TheProgrammingInn.Com.Repository;
using TheProgrammingInn.Com.ViewModels;

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

        [HttpPost]
        public IActionResult Comment(CommentViewModel viewModel)
        {
            using (_context)
            {
                if (!ModelState.IsValid)
                    return RedirectToAction("Index", new { title = viewModel.BlogTitle });

                var blog = new BlogRepository(_context).GetByTitle(viewModel.BlogTitle);
                if (viewModel.MainCommentId == 0)
                {
                    blog.MainComments = blog.MainComments ?? new List<MainComment>();
                    blog.MainComments.Add(new MainComment
                    {
                        Message = viewModel.Message,
                        Created = DateTime.Now,
                    });
                    new BlogRepository(_context).Update(blog);
                }
                else
                {
                    var comment = new SubComment
                    {
                        MainCommentId = viewModel.MainCommentId,
                        Message = viewModel.Message,
                        Created = DateTime.Now
                    };
                    new SubCommentRepository(_context).Insert(comment);
                }
            }
            return RedirectToAction("Index", new { title = viewModel.BlogTitle });
        }
    }
}
