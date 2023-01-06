using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace IdentityProject.Models
{
    public class EmailData
    {
        public string EmailToName { get; set; }
        public string EmailToId { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
    }
    public class EmailService:IEmailSender
    {
        private readonly IConfiguration config;

        public EmailService(IConfiguration config)
        {
            this.config = config;
        }
        public bool SendEmail(EmailData emailData)
        {
            try
            {
                MimeMessage emailMessage = new MimeMessage();
                MailboxAddress emailFrom = new MailboxAddress("Admin", "saheelsheikh4076@gmail.com");
                emailMessage.From.Add(emailFrom);
                MailboxAddress emailTo = new MailboxAddress(emailData.EmailToName, emailData.EmailToId);
                emailMessage.To.Add(emailTo);
                emailMessage.Subject = emailData.EmailSubject;
                BodyBuilder emailBodyBuilder = new BodyBuilder();
                emailBodyBuilder.HtmlBody = emailData.EmailBody;
                emailMessage.Body = emailBodyBuilder.ToMessageBody();

                using (SmtpClient emailClient = new SmtpClient())
                {
                    var port = Convert.ToInt32(config.GetSection("EmailSettings:Port").Value);
                    var sslRequired = Convert.ToBoolean(config.GetSection("EmailSettings:SSL").Value);
                    emailClient.Connect(config.GetSection("EmailSettings:ServerName").Value??"",port, sslRequired);
                    emailClient.Authenticate(config.GetSection("EmailSettings:Username").Value, 
                        config.GetSection("EmailSettings:Password").Value);
                    emailClient.Send(emailMessage);
                    emailClient.Disconnect(true);
                    emailClient.Dispose(); 
                }
                return true;
            }
            catch (Exception ex)
            {
                //Log Exception Details
                return false;
            }
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SendEmail(new EmailData
            {
                EmailBody = htmlMessage,
                EmailSubject = subject,
                EmailToId = email,
                EmailToName = email
            });
        }
    }
}
