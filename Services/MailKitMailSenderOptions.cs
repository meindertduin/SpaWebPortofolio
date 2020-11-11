using MailKit.Security;

namespace SpaWebPortofolio.Services
{
    public class MailKitMailSenderOptions
    {
        public MailKitMailSenderOptions()
        {
            HostSecureSocketOptions = SecureSocketOptions.Auto;
        }
 
        public string HostAddress { get; set; }
 
        public int HostPort { get; set; }
 
        public string HostUsername { get; set; }
 
        public string HostPassword { get; set; }
 
        public SecureSocketOptions HostSecureSocketOptions { get; set; }
 
        public string SenderEMail { get; set; }
 
        public string SenderName { get; set; }
    }
}