using System.Threading.Tasks;
using FluentEmail;
using FluentEmail.Core;
using Ganss.XSS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SpaWebPortofolio.Data;

namespace SpaWebPortofolio.Controllers
{
    [ApiController]
    [Route("api/contactMessage")]
    public class ContactMessageController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private IConfiguration _configuration;

        public ContactMessageController(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
        }
        
        [HttpPost]
        public async Task<IActionResult> Upload([FromBody] ContactMessageForm contactMessage)
        {
            var sanitizer = new HtmlSanitizer();
            
            contactMessage.Email = sanitizer.Sanitize(contactMessage.Email);
            contactMessage.Name = sanitizer.Sanitize(contactMessage.Name);
            contactMessage.Subject = sanitizer.Sanitize(contactMessage.Subject);
            contactMessage.Message = sanitizer.Sanitize(contactMessage.Message);
            
            await Email
                .From(contactMessage.Email)
                .To(_configuration["ContactAddress"])
                .Subject($"{contactMessage.Name} heeft gereageerd via je website")
                .Body(contactMessage.Message)
                .SendAsync();
            
            return Ok();
        }
    }
}