using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheProgrammingInn.Com.Data;
using TheProgrammingInn.Com.Models;

namespace TheProgrammingInn.Com.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly Context _context;
        public BlogRepository(Context context)
        {
            _context = context;
        }
        public void Insert(Blog toInsert)
        {
            _context.Blogs.Add(toInsert);
            _context.SaveChanges();

        }
        public Blog GetByTitle(string title) => _context.Blogs.SingleOrDefault(p => p.Title == title);
        //public List<Page> GetAllPages() => _context.Pages.ToList();
        public IList<Blog> GetAllPages()
        {
            IList<Blog> preImageConversion = _context.Blogs.Include(p => p.DisplayImage).ToList();
            IList<Blog> postImageConversion = new List<Blog>();
            foreach(var pre in preImageConversion)
            {
                string imageBase64Data = Convert.ToBase64String(pre.DisplayImage.ImageData);

                string imageDataURL = string.Format("data:image/jpg;base64, {0}", imageBase64Data);
                pre.ImageDataURL = imageDataURL;
                postImageConversion.Add(pre);
            }

            return postImageConversion;
        }

        public Blog Update(Blog pageToChange)
        {
            var updatedPage = _context.Blogs.Attach(pageToChange);
            updatedPage.State = EntityState.Modified;
            _context.SaveChanges();

            return pageToChange;
        }
        public Blog Delete(string title)
        {
            Blog page = _context.Blogs.Find(title);

            if(page != null)
            {
                _context.Blogs.Remove(page);
                _context.SaveChanges();
            }
            return page;
        }
    }
}
