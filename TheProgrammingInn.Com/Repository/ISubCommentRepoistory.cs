using System.Collections.Generic;
using TheProgrammingInn.Com.Models;

namespace TheProgrammingInn.Com.Repository
{
    public interface ISubCommentRepoistory
    {
        void Insert(SubComment toInsert);
        SubComment GetById(int id);
        SubComment Update(SubComment commentToChange);
        SubComment Delete(int id);
        IList<SubComment> GetAllSubCommentsByMainCommentId(int id);
    }
}
