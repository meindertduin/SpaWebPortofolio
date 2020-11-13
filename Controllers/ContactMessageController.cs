using System;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
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
        private readonly IMailer _mailer;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _appDbContext;

        public ContactMessageController(AppDbContext appDbContext, IMailer mailer, IWebHostEnvironment webHostEnvironment)
        {
            _mailer = mailer;
            _webHostEnvironment = webHostEnvironment;
            _appDbContext = appDbContext;

        }

        
        [HttpPost]
        public async Task<IActionResult> Upload([FromBody] ContactMessageForm contactMessage)
        {
            _appDbContext.ContactMessages.Add(new ContactMessage()
            {
                Name = contactMessage.Name,
                Subject = contactMessage.Subject,
                Message = contactMessage.Message,
                Email = contactMessage.Email,
            });

            _appDbContext.SaveChanges();

            await _mailer.SendEmailAsync("meindertvanduin99@gmail.com", $"Message from {contactMessage.Email}", contactMessage);

            return Ok();
        }
    }
}