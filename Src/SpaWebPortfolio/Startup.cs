using System.Net.Mail;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpaWebPortofolio.Data;
using SpaWebPortofolio.Interfaces;
using SpaWebPortofolio.Services;

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

            services
                .AddFluentEmail(Configuration["ContactAddress"])
                .AddSmtpSender(() =>
                {
                    if (_webHostEnvironment.IsDevelopment())
                    {
                        return new SmtpClient("127.0.0.1", 25)
                        {
                            EnableSsl = false,
                            UseDefaultCredentials = true,
                        };
                    }

                    return new SmtpClient("127.0.0.1", 25);
                });

            services.AddRazorPages();

            services.AddTransient<IImageCuttingService, ImageCuttingService>();

            services.AddDbContext<ApplicationDbContext>(config =>
            {
                if (_webHostEnvironment.IsDevelopment())
                {
                    config.UseInMemoryDatabase("Dev");
                }
                else
                {
                    var conn = Configuration["ConnectionStrings:SpaDatabase"];
                    config.UseSqlServer(conn, b =>
                    {
                        b.MigrationsAssembly("SpaWebPortofolio");
                    });
                }
            });
            
            services.AddDbContext<IdentityUserDbContext>(builder =>
            {
                builder.UseInMemoryDatabase("IdentityDb");
            });

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    options.User.RequireUniqueEmail = true;

                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
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
            
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpaOrigin",
                    builder =>
                    {
                        builder
                            .AllowCredentials()
                            .WithOrigins(Configuration["SpaBaseUrl"])
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

                var forwardOptions = new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
                    RequireHeaderSymmetry = false
                };

                forwardOptions.KnownNetworks.Clear();
                forwardOptions.KnownProxies.Clear();

                app.UseForwardedHeaders(forwardOptions);
            }

            app.UseCors("AllowSpaOrigin");
            
            app.UseStaticFiles();
            
            app.UseRouting();
            
            app.UseCookiePolicy(new CookiePolicyOptions()
            {
                MinimumSameSitePolicy = SameSiteMode.None,
                Secure = CookieSecurePolicy.Always,
            });
            
            app.UseAuthentication();
            
            app.UseIdentityServer();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                

                endpoints.MapRazorPages();
            });
        }
    }
}