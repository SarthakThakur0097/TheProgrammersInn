using System.ComponentModel.DataAnnotations;

namespace TheProgrammingInn.Com.Models
{
    public class User
    {
        public User(){}
        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
