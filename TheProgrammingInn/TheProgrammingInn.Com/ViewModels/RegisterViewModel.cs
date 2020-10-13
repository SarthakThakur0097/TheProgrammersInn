using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TheProgrammingInn.Com.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        //Attribute used for custom domain validation
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}
