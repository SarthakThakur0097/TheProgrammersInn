using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TheProgrammingInn.Com.Data;
using TheProgrammingInn.Com.Models;

namespace TheProgrammingInn.Com
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            try
            {


                var scope = host.Services.CreateScope();

                var context = scope.ServiceProvider.GetRequiredService<Context>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                context.Database.EnsureCreated();

                var adminRole = new IdentityRole("Admin");
                if (!context.Roles.Any())
                {
                    roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
                }
                if (!context.Users.Any(u => u.UserName == "admin"))
                {
                    var adminUser = new ApplicationUser
                    {
                        FirstName = "Admin",
                        LastName = "Admin",
                        UserName = "admin",
                        Email = "admin@gmail.com"
                    };
                    userManager.CreateAsync(adminUser, "password").GetAwaiter().GetResult();
                    userManager.AddToRoleAsync(adminUser, adminRole.Name);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
