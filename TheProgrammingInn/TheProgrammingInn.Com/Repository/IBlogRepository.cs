using System.Collections.Generic;
using TheProgrammingInn.Com.Models;

namespace TheProgrammingInn.Com.Repository
{
    public interface IBlogRepository
    {
        void Insert(Blog toInsert);
        Blog GetByTitle(string title);
        Blog Update(Blog pageToChange);
        Blog Delete(string title);
        IList<Blog> GetAllBlogs();
    }
}
