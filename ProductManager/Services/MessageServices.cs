using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ProductManager.Services
{
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public AuthMessageSender(IOptions<SMSoptions> SMSoptionsAccessor, IOptions<AuthMessageSenderOptions> EMAILoptionsAccessor)
        {
            EMAILOptions = EMAILoptionsAccessor.Value;
            SMSOptions = SMSoptionsAccessor.Value;
        }

        public SMSoptions SMSOptions { get; }  // set only via Secret Manager
        public AuthMessageSenderOptions EMAILOptions { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            Execute(EMAILOptions.SendGridKey, subject, message, email).Wait();
            return Task.FromResult(0);
        }

        public async Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("noreply@istvan.com", "ASP.NET MVC verification"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            var response = await client.SendEmailAsync(msg);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            // Your Account SID from twilio.com/console
            var accountSid = SMSOptions.accountSid;
            // Your Auth Token from twilio.com/console
            var authToken = SMSOptions.authToken;

            TwilioClient.Init(accountSid, authToken);

            var msg = MessageResource.Create(
              to: new PhoneNumber(number),
              from: new PhoneNumber("+14023958362"),
              body: message);

            return Task.FromResult(0);
        }
    }
}
