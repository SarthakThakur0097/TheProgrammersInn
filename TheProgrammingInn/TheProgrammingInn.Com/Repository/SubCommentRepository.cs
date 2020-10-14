using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheProgrammingInn.Com.Data;
using TheProgrammingInn.Com.Models;

namespace TheProgrammingInn.Com.Repository
{
    public class SubCommentRepository : ISubCommentRepoistory
    {
        private readonly Context _context;
        public SubCommentRepository(Context context)
        {
            _context = context;
        }
        public void Insert(SubComment toInsert)
        {
            _context.SubComments.Add(toInsert);
            _context.SaveChanges();

        }
        public SubComment GetById(int id) => _context.SubComments.SingleOrDefault(mc => mc.Id == id);
        public IList<SubComment> GetAllSubCommentsByMainCommentId(int id) => _context.SubComments
            .Include(sc => sc.MainComment)
            .Where(sc => sc.MainCommentId == id)
            .ToList();

        public SubComment Update(SubComment commentToChange)
        {
            var updatedComment = _context.SubComments.Attach(commentToChange);
            updatedComment.State = EntityState.Modified;
            _context.SaveChanges();

            return commentToChange;
        }
        public SubComment Delete(int id)
        {
            SubComment comment = _context.SubComments.Find(id);

            if (comment != null)
            {
                _context.SubComments.Remove(comment);
                _context.SaveChanges();
            }
            return comment;
        }
    }
}
