using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheProgrammingInn.Com.Data;
using TheProgrammingInn.Com.Models;

namespace TheProgrammingInn.Com.Repository
{
    public class PagesRepository : IPagesRepository
    {
        private readonly Context _context;
        public PagesRepository(Context context)
        {
            _context = context;
        }
        public void Insert(Page toInsert)
        {
            _context.Pages.Add(toInsert);
            _context.SaveChanges();

        }
        public Page GetByTitle(string title) => _context.Pages.SingleOrDefault(p => p.Title == title);
        //public List<Page> GetAllPages() => _context.Pages.ToList();
        public IList<Page> GetAllPages()
        {
            IList<Page> preImageConversion = _context.Pages.Include(p => p.DispalyImage).ToList();
            IList<Page> postImageConversion = new List<Page>();
            foreach(var pre in preImageConversion)
            {
                string imageBase64Data = Convert.ToBase64String(pre.DispalyImage.ImageData);

                string imageDataURL = string.Format("data:image/jpg;base64, {0}", imageBase64Data);
                pre.ImageDataURL = imageDataURL;
                postImageConversion.Add(pre);
            }

            return postImageConversion;
        }

        public Page Update(Page pageToChange)
        {
            var updatedPage = _context.Pages.Attach(pageToChange);
            updatedPage.State = EntityState.Modified;
            _context.SaveChanges();

            return pageToChange;
        }
        public Page Delete(string title)
        {
            Page page = _context.Pages.Find(title);

            if(page != null)
            {
                _context.Pages.Remove(page);
                _context.SaveChanges();
            }
            return page;
        }
    }
}
