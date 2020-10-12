using System.ComponentModel.DataAnnotations;
using TheProgrammingInn.Com.Models;

namespace TheProgrammingInn.Com.ViewModels
{
    public class PageViewModel
    { 
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "Description")]
        public string Description { get; set; }
#nullable enable
        public Image? DisplayImage { get; set; }
    }
}
