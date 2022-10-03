

namespace CPTool.Infrastructure.MailService
{
    public class EmailService : IEmailService
    {
        public EMailSettings EmailSettings { get; }
        public ILogger<EMailSettings> _logger { get; }

        public EmailService(IOptions<EMailSettings> emailSettings, ILogger<EMailSettings> logger)
        {
            EmailSettings = emailSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmail(EMail mail)
        {
            var client = new SendGridClient(EmailSettings.ApiKey);
            var subject = mail.Subject;
            var to = new EmailAddress(mail.To);
            var emailbody = mail.Body;
            var from = new EmailAddress
            {
                Email = EmailSettings.FromAdress,
                Name = EmailSettings.FromName,
            };
            var sendgridMessage = MailHelper.CreateSingleEmail(
                from,
                to, subject,
                emailbody, emailbody

                );

            var response = await client.SendEmailAsync(sendgridMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;

            _logger.LogError("Mail no send it!");

            return false;
        }
    }
}

