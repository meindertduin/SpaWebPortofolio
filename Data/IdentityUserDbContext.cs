using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SpaWebPortofolio.Data
{
    public class IdentityUserDbContext : IdentityDbContext
    {
        public IdentityUserDbContext(DbContextOptions<IdentityUserDbContext> options) : base(options)
        {
            
        }
    }
}