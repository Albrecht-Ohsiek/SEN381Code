using CallCenter.Types;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace CallCenter.Services
{
    //implements email notification services using SendGrid API
    public class EmailNotificationServices : INotificationStrategy
    {
        private readonly string sendGridApiKey = "paste here";
        private readonly EmailAddress fromEmail = new EmailAddress("ruludick+sen381@gmail.com", "Premier Service Solutions");

        public void Notify(string message, string recipientEmail)
        {
            
              var client = new SendGridClient(sendGridApiKey);
              var to = new EmailAddress(recipientEmail);
              var subject = "New Express Work Request";
              var mail = MailHelper.CreateSingleEmail(fromEmail, to, subject, message, null);
              var response = client.SendEmailAsync(mail).GetAwaiter().GetResult();

        }
    }
}
