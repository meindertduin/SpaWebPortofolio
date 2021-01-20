using System.Threading.Tasks;
using FluentEmail.Core;
using Ganss.XSS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SpaWebPortofolio.Controllers
{
    [ApiController]
    [Route("api/contactMessage")]
    public class ContactMessageController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ContactMessageController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [HttpPost]
        public async Task<IActionResult> Upload([FromBody] ContactMessageForm contactMessage, [FromServices] IFluentEmail fluentEmail)
        {
            var sanitizer = new HtmlSanitizer();
            
            contactMessage.Email = sanitizer.Sanitize(contactMessage.Email);
            contactMessage.Name = sanitizer.Sanitize(contactMessage.Name);
            contactMessage.Subject = sanitizer.Sanitize(contactMessage.Subject);
            contactMessage.Message = sanitizer.Sanitize(contactMessage.Message);
            
            fluentEmail
                .To(_configuration["ContactAddress"])
                .Subject($"{contactMessage.Name} heeft gereageerd via je website")
                .Body(contactMessage.Message);

            await fluentEmail.SendAsync();
            
            return Ok();
        }
    }
}