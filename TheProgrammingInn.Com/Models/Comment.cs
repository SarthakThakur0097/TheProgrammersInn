using System;

namespace TheProgrammingInn.Com.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
