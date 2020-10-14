using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheProgrammingInn.Com.Models;

namespace TheProgrammingInn.Com.Repository
{
    public interface IMainCommentRepository
    {
        void Insert(MainComment toInsert);
        MainComment GetById(int id);
        MainComment Update(MainComment commentToChange);
        MainComment Delete(int id);
    }
}
