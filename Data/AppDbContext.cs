using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpaWebPortofolio.Controllers;

namespace SpaWebPortofolio.Data
{
    public class AppDbContext : IdentityDbContext
    {
        protected AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }

        public DbSet<ContactMessage> ContactMessages { get; set; }
    }
}