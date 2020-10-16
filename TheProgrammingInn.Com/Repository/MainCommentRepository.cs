using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TheProgrammingInn.Com.Data;
using TheProgrammingInn.Com.Models;

namespace TheProgrammingInn.Com.Repository
{
    public class MainCommentRepository : IMainCommentRepository
    {
        private readonly Context _context;
        public MainCommentRepository(Context context)
        {
            _context = context;
        }
        public void Insert(MainComment toInsert)
        {
            _context.MainComments.Add(toInsert);
            _context.SaveChanges();

        }
        public MainComment GetById(int id) => _context.MainComments.SingleOrDefault(mc => mc.Id == id);
        public IList<MainComment> GetAllCommentsByBlogTitle(string title) => _context.MainComments
            .Include(mc => mc.Blog)
            .Where(mc => mc.Blog.Title == title)
            .ToList();

        public MainComment Update(MainComment commentToChange)
        {
            var updatedComment = _context.MainComments.Attach(commentToChange);
            updatedComment.State = EntityState.Modified;
            _context.SaveChanges();

            return commentToChange;
        }
        public MainComment Delete(int id)
        {
            MainComment comment = _context.MainComments.Find(id);

            if (comment != null)
            {
                _context.MainComments.Remove(comment);
                _context.SaveChanges();
            }
            return comment;
        }
    }
}
