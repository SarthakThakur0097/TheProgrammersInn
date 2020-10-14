using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TheProgrammingInn.Com.Models;

namespace TheProgrammingInn.Com.Data
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        override public DbSet<ApplicationUser> Users { get; set; }

        public Context(DbContextOptions<Context> options) :base(options){}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach( var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<MainComment> MainComments { get; set; }
        public DbSet<SubComment> SubComments { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
