using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;

namespace Weartherapp.Services
{
    public class EmailSender
    {
        private readonly string apiKey = "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";
        private readonly string senderEmail = "dishadavda3899@gmail.com";
        private readonly string senderName = "Weather App";

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(senderEmail, senderName);
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
