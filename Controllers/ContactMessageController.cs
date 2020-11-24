using System;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
using Ganss.XSS;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SpaWebPortofolio.Data;
using SpaWebPortofolio.Services;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace SpaWebPortofolio.Controllers
{
    [ApiController]
    [Route("api/contactMessage")]
    public class ContactMessageController : ControllerBase
    {
        private readonly IMailerService _mailerService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext _applicationDbContext;

        public ContactMessageController(ApplicationDbContext applicationDbContext, IMailerService mailerService, IWebHostEnvironment webHostEnvironment)
        {
            _mailerService = mailerService;
            _webHostEnvironment = webHostEnvironment;
            _applicationDbContext = applicationDbContext;

        }
        
        [HttpPost]
        public async Task<IActionResult> Upload([FromBody] ContactMessageForm contactMessage)
        {
            var sanitizer = new HtmlSanitizer();
            
            contactMessage.Email = sanitizer.Sanitize(contactMessage.Email);
            contactMessage.Name = sanitizer.Sanitize(contactMessage.Name);
            contactMessage.Subject = sanitizer.Sanitize(contactMessage.Subject);
            contactMessage.Message = sanitizer.Sanitize(contactMessage.Message);
            
            _applicationDbContext.ContactMessages.Add(new ContactMessage()
            {
                Name = contactMessage.Name,
                Subject = contactMessage.Subject,
                Message = contactMessage.Message,
                Email = contactMessage.Email,
            });

            _applicationDbContext.SaveChanges();
            
            //await _mailerService.SendEmailAsync("meindertvanduin99@gmail.com", $"Message from {contactMessage.Email}", contactMessage);

            return Ok();
        }
    }
}