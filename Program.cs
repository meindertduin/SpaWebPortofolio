using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using CertificateManager;
using CertificateManager.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SpaWebPortofolio.Data;

namespace SpaWebPortofolio
{
    public class Program
    {
        static CreateCertificates _cc;
        public static void Main(string[] args)
        {
            var sp = new ServiceCollection()
                .AddCertificateManager()
                .BuildServiceProvider();
 
            _cc = sp.GetService<CreateCertificates>();
 
            var rsaCert = CreateRsaCertificate(Environment.GetEnvironmentVariable("DNSName")??"localhost", 10);

            string password = Environment.GetEnvironmentVariable("IdentityCertPassword") ?? "1234";
            var iec = sp.GetService<ImportExportCertificate>();
 
            var rsaCertPfxBytes = 
                iec.ExportSelfSignedCertificatePfx(password, rsaCert);
            File.WriteAllBytes("rsaCert.pfx", rsaCertPfxBytes);

            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                var admin = new IdentityUser("admin"){ Email = "meindertwebportofolio@gmail.com"};
                
                var adminPassword = configuration["AdminPassword"];

                userManager.CreateAsync(admin, adminPassword).GetAwaiter().GetResult();
                
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

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        
        public static X509Certificate2 CreateRsaCertificate(
            string dnsName, int validityPeriodInYears)
        {
            var basicConstraints = new BasicConstraints
            {
                CertificateAuthority = false,
                HasPathLengthConstraint = false,
                PathLengthConstraint = 0,
                Critical = false
            };
 
            var subjectAlternativeName = new SubjectAlternativeName
            {
                DnsName = new List<string>{ dnsName }
            };
 
            var x509KeyUsageFlags = X509KeyUsageFlags.DigitalSignature;
 
            // only if certification authentication is used
            var enhancedKeyUsages = new OidCollection
            {
                new Oid("1.3.6.1.5.5.7.3.1"),  // TLS Server auth
                new Oid("1.3.6.1.5.5.7.3.2"),  // TLS Client auth
            };
 
            var certificate = _cc.NewRsaSelfSignedCertificate(
                new DistinguishedName { CommonName = dnsName },
                basicConstraints,
                new ValidityPeriod
                {
                    ValidFrom = DateTimeOffset.UtcNow,
                    ValidTo = DateTimeOffset.UtcNow.AddYears(validityPeriodInYears)
                },
                subjectAlternativeName,
                enhancedKeyUsages,
                x509KeyUsageFlags,
                new RsaConfiguration { KeySize = 2048 }
            );
 
            return certificate;
        }
    }
}
