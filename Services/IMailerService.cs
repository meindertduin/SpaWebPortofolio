using System.Threading.Tasks;
using SpaWebPortofolio.Controllers;

namespace SpaWebPortofolio.Services
{
    public interface IMailerService
    {
        Task SendEmailAsync(string email, string subject, ContactMessageForm contactMessageForm);
    }
}