using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Movie.Business.Utilities.Email
{
    public class EmailHelper : IEmailHelper
    {
        private EmailSetting _emailSetting;

        public EmailHelper(IOptions<EmailSetting> emailSetting)
        {
            _emailSetting = emailSetting.Value;
        }

        public async Task<bool> SendEmailAsync(string to, string content)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(_emailSetting.Mail);
                email.To.Add(MailboxAddress.Parse(to));
                email.Subject = "Movie Advice";

                var builder = new BodyBuilder();

                builder.TextBody = $"You should watch movie which name is {content}";

                email.Body = builder.ToMessageBody();
                SmtpClient smtp = new SmtpClient();
                smtp.Connect(_emailSetting.Host, _emailSetting.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailSetting.Mail, _emailSetting.Password);
                var result = await smtp.SendAsync(email);
                smtp.Disconnect(true);

                return result != null ? true : false;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
