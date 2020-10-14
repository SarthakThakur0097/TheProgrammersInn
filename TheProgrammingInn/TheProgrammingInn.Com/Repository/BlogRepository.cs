using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public Blog GetByTitle(string title) => ImageConversion(_context.Blogs
            .Include(p => p.DisplayImage)
            .Include(p => p.MainComments)
                .ThenInclude(mc => mc.SubComments)
            .SingleOrDefault(p => p.Title == title));
        public IList<Blog> GetAllPages() => ImageConversion(_context.Blogs
            .Include(p => p.DisplayImage)
            .ToList());
      
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
        public Blog ImageConversion(Blog toConvert)
        {
            string imageBase64Data = Convert.ToBase64String(toConvert.DisplayImage.ImageData);

            string imageDataURL = string.Format("data:image/jpg;base64, {0}", imageBase64Data);
            toConvert.ImageDataURL = imageDataURL;
            return toConvert;
        }

        public IList<Blog> ImageConversion(IList<Blog> toConvertList)
        {
            IList<Blog> postImageConversion = new List<Blog>();
            foreach (var pre in toConvertList)
            {
                string imageBase64Data = Convert.ToBase64String(pre.DisplayImage.ImageData);

                string imageDataURL = string.Format("data:image/jpg;base64, {0}", imageBase64Data);
                pre.ImageDataURL = imageDataURL;
                postImageConversion.Add(pre);
            }
            return postImageConversion;
        }
    }
}
