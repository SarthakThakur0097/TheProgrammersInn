using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheProgrammingInn.Com.Models
{
    public class Page
    {
        [Key]
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        #nullable enable
        public Image? DispalyImage { get; set; }
        [NotMapped]
        public string ImageDataURL { get; set; }

    }
}
