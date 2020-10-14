using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheProgrammingInn.Com.Models
{
    public class ApplicationUserRole: IdentityUserRole<string>
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
