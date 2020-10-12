using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheProgrammingInn.Com.Models
{
    public class Blog
    {
        public Blog(){}
        public Blog(string title, string description, string content, Image displayImage)
        {
            Title = title;
            Description = description;
            Content = content;
            DisplayImage = displayImage;
        }

        [Key]
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        #nullable enable
        public Image? DisplayImage { get; set; }
        [NotMapped]
        public string ImageDataURL { get; set; }
    }
}
