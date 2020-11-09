using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpaWebPortofolio.Controllers;

namespace SpaWebPortofolio.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        protected AppDbContext(DbContextOptions<IdentityDbContext<IdentityUser>> options) : base(options)
        {
            
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
    }
}