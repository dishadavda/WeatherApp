using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;
using Weartherapp.Data;

namespace Weartherapp.Services
{
    public class EmailSender
    {
        private readonly string _apiKey;
        private readonly string _senderEmail;
        private readonly string _senderName;

        public EmailSender(IOptions<SendGridSettings> options)
        {
            var settings = options.Value;
            _apiKey = settings.ApiKey;
            _senderEmail = settings.SenderEmail;
            _senderName = settings.SenderName;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress(_senderEmail, _senderName);
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
