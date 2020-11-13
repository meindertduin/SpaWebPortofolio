using MailKit.Security;

namespace SpaWebPortofolio.Services
{
    public class MailKitMailSenderOptions
    {

        public string HostAddress { get; set; }
 
        public int HostPort { get; set; }
 
        public string HostUsername { get; set; }
 
        public string HostPassword { get; set; }
        public string SenderEmail { get; set; }
 
        public string SenderName { get; set; }
    }
}