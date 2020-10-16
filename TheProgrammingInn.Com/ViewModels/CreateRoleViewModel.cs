using System.ComponentModel.DataAnnotations;

namespace TheProgrammingInn.Com.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name="Role Name")]
        public string RoleName { get; set; }
    }
}
