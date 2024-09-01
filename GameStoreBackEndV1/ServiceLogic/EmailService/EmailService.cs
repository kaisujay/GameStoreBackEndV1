using GameStoreBackEndV1.ObjectLogic.ObjectDTOs.Email;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace GameStoreBackEndV1.ServiceLogic.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public void SendEmail(SendEmailDto emailDto)        //https://www.youtube.com/watch?v=PvO_1T0FS_A
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailConfig:From").Value));
            email.To.Add(MailboxAddress.Parse(emailDto.EmailTo));
            email.Subject = emailDto.EmailSubject;
            email.Body = new TextPart(TextFormat.Text) { Text = emailDto.EmailSubject };

            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailConfig:SmtpServer").Value, Convert.ToInt32(_config.GetSection("EmailConfig:Port").Value), SecureSocketOptions.StartTls);
            smtp.Authenticate(_config.GetSection("EmailConfig:UserName").Value, _config.GetSection("EmailConfig:Password").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
            smtp.Dispose();
        }
    }
}
