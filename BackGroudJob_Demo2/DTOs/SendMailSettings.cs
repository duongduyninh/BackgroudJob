using MailKit.Security;

namespace BackGroudJob_Demo2.DTOs
{
    public class SendMailSettings
    {
        public string SmtpServer { get; set; }
        public string? SenderEmail { get; set; }
        public string? SenderName { get; set; }
        public string? Password { get; set; }
        public int SmtpPort { get; set; }
        public bool StatusAuthentication { get; set; } 

    }

}
