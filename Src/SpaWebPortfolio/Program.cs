using System;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SpaWebPortofolio.Data;

namespace SpaWebPortofolio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                SetupAdminAccount(scope);

                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    if (context.Database.GetPendingMigrations().Any())
                    {
                        context.Database.Migrate();
                    }
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        private static void SetupAdminAccount(IServiceScope scope)
        {
            var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var admin = new IdentityUser("admin") {Email = "meindertwebportofolio@gmail.com"};

            var adminPassword = configuration["AdminPassword"];
            var creationResult = userManager.CreateAsync(admin, adminPassword).GetAwaiter().GetResult();

            if (creationResult.Succeeded == false)
            {
                var adminUser = userManager.FindByNameAsync("admin").GetAwaiter().GetResult();
                var token = userManager.GeneratePasswordResetTokenAsync(adminUser).GetAwaiter().GetResult();
                var resetResult = userManager.ResetPasswordAsync(adminUser, token, adminPassword).GetAwaiter().GetResult();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseWebRoot("wwwroot");
    }
}
