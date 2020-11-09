using Microsoft.AspNetCore.Mvc;
using SpaWebPortofolio.Data;

namespace SpaWebPortofolio.Controllers
{
    [ApiController]
    [Route("api/contactMessage")]
    public class ContactMessageController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ContactMessageController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        [HttpPost]
        public IActionResult Upload([FromBody] ContactMessageForm contactMessage)
        {
            _appDbContext.ContactMessages.Add(new ContactMessage()
            {
                Name = contactMessage.Name,
                Subject = contactMessage.Subject,
                Message = contactMessage.Message,
                Email = contactMessage.Email,
            });

            _appDbContext.SaveChanges();

            return Accepted();
        }
    }
}