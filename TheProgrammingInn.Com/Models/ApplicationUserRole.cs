using Microsoft.AspNetCore.Identity;

namespace TheProgrammingInn.Com.Models
{
    public class ApplicationUserRole: IdentityUserRole<string>
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
