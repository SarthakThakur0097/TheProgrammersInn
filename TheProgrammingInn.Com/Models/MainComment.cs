using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheProgrammingInn.Com.Models
{
    public class MainComment : Comment
    {
        public List<SubComment> SubComments { get; set; }
        public string BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
