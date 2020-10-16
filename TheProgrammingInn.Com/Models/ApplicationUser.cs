using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheProgrammingInn.Com.Models
{
    [NotMapped]
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(){}
        public ApplicationUser(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public IList<MainComment> MainComments { get; set; }
        public IList<SubComment> SubComments { get; set; }

    }
}
