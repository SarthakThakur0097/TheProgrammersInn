using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheProgrammingInn.Com.Models;

namespace TheProgrammingInn.Com.Repository
{
    public interface IPagesRepository
    {
        void Insert(Page toInsert);
        Page GetByTitle(string title);
        Page Update(Page pageToChange);
        Page Delete(string title);
        IList<Page> GetAllPages();

    }
}
