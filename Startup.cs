using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpaWebPortofolio.Data;
using SpaWebPortofolio.Interfaces;
using SpaWebPortofolio.Services;
using VueCliMiddleware;

namespace SpaWebPortofolio
{
    public class Startup
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            Configuration = configuration;
            StaticConfig = configuration;
        }

        public IConfiguration Configuration { get; private set; }
        public static IConfiguration StaticConfig { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.Configure<MailKitMailSenderOptions>(Configuration.GetSection("SmptHostSettings"));
            services.AddSingleton<IMailerService, AutoMessageMailerServiceService>();

            services.AddRazorPages();

            services.AddTransient<IImageCuttingService, ImageCuttingService>();

            services.AddDbContext<ApplicationDbContext>(config =>
            {
                if (_webHostEnvironment.IsDevelopment())
                {
                    config.UseInMemoryDatabase("Dev");
                    // var conn = Configuration["ConnectionStrings:SpaDatabase"];
                    // config.UseSqlServer(conn, b =>
                    // {
                    //     b.MigrationsAssembly("SpaWebPortofolio");
                    // });
                }
                else
                {
                    config.UseInMemoryDatabase("Dev");
                    // var conn = Configuration["ConnectionStrings:SpaDatabase"];
                    // config.UseSqlServer(conn, b =>
                    // {
                    //     b.MigrationsAssembly("SpaWebPortofolio");
                    // });
                }
            });
            
            // identity db context
            services.AddDbContext<IdentityUserDbContext>(builder =>
            {
                builder.UseInMemoryDatabase("IdentityDb");
            });

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;

                    if (_webHostEnvironment.IsDevelopment())
                    {
                        options.Password.RequireDigit = false;
                        options.Password.RequiredLength = 6;
                        options.Password.RequireUppercase = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireNonAlphanumeric = false;
                    }
                    else
                    {
                        options.Password.RequireDigit = true;
                        options.Password.RequiredLength = 8;
                        options.Password.RequireUppercase = true;
                        options.Password.RequireLowercase = true;
                        options.Password.RequireNonAlphanumeric = false;
                    }
                })
                .AddEntityFrameworkStores<IdentityUserDbContext>()
                .AddDefaultTokenProviders();
            
            var identityServiceBuilder = services.AddIdentityServer();
            identityServiceBuilder.AddAspNetIdentity<IdentityUser>();
            
            
            identityServiceBuilder.AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseInMemoryDatabase("IdentityDb");
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseInMemoryDatabase("IdentityDb");
                })
                .AddInMemoryIdentityResources(DevelopmentIdentityConfiguration.GetIdentityResources())
                .AddInMemoryClients(DevelopmentIdentityConfiguration.GetClients())
                .AddInMemoryApiScopes(DevelopmentIdentityConfiguration.GetApiScopes());

            identityServiceBuilder.AddDeveloperSigningCredential();

            services.AddLocalApiAuthentication();

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Account/Login";
                config.LogoutPath = "/api/auth/logout";
            });
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", builder =>
                {
                    builder.RequireAuthenticatedUser();
                });
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
                //configuration.RootPath = "/public/";
            });
            
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder
                            .AllowCredentials()
                            .WithOrigins("https://localhost:5001")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseCors("AllowAllOrigins");
            
            app.UseStaticFiles();

            app.UseSpaStaticFiles();
            
            app.UseRouting();
            
            app.UseAuthentication();
            
            app.UseIdentityServer();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");

                if (env.IsDevelopment())
                {
                    endpoints.MapToVueCliProxy(
                        "{*path}",
                        new SpaOptions { SourcePath = "ClientApp" },
                        npmScript: "serve",
                        regex: "Compiled successfully");
                }

                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
            });
        }
    }
}
