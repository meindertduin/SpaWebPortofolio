using System;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using SpaWebPortofolio.Controllers;

namespace SpaWebPortofolio.Services
{
    public class Mailer : IMailer
    {
        private readonly MailKitMailSenderOptions _smptSettings;
        private readonly IWebHostEnvironment _environment;

        public Mailer(IOptions<MailKitMailSenderOptions> smptSettings, IWebHostEnvironment environment)
        {
            _smptSettings = smptSettings.Value;
            _environment = environment;
        }
        
        public async Task SendEmailAsync(string email, string subject, ContactMessageForm contactMessageForm)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_smptSettings.SenderName, _smptSettings.SenderEmail));
                message.To.Add(new MailboxAddress(email));
                message.Subject = $"WebPortofolio, nieuw bericht van: {contactMessageForm.Name}";
                
                var builder = new BodyBuilder();
                
                builder.HtmlBody = string.Format(@"<p>Geachte heer Meindert,<br>
                <p>U heeft een nieuw bericht van: {0}<br>
                <p>Betreft: {3}
                <p>Bericht:<br>
                {1}<br>
                <p>De achtergelaten email is: {2}
                <br>
                <p>Groetjes MeindertBot
                ", contactMessageForm.Name, contactMessageForm.Message, contactMessageForm.Email, contactMessageForm.Subject);

                message.Body = builder.ToMessageBody();
                
                using var client = new SmtpClient();
                
                if (_environment.IsDevelopment())
                {
                    await client.ConnectAsync(_smptSettings.HostAddress, _smptSettings.HostPort, false);
                }
                else
                {
                    await client.ConnectAsync(_smptSettings.HostAddress);
                    await client.AuthenticateAsync(_smptSettings.HostUsername, _smptSettings.HostPassword);
                }

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}