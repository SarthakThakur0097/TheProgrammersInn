using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheProgrammingInn.Com.ViewModels
{
    public class CommentViewModel
    {
        [Required]
        public string PostId { get; set; }
        [Required]
        public int MainCommentId { get; set; }
        [Required]
        public string Message { get; set; }

    }
}
