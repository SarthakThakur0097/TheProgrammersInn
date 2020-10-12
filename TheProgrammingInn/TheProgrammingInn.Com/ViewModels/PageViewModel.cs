using System.ComponentModel.DataAnnotations;
using TheProgrammingInn.Com.Models;

namespace TheProgrammingInn.Com.ViewModels
{
    public class PageViewModel
    { 
        [Display(Name = "Title")]
        public string Title { get; set; }
        public string Content { get; set; }
        [Display(Name = "Description")]
        [StringLength(75)]
        public string Description { get; set; }
#nullable enable
        public Image? DisplayImage { get; set; }
    }
}
