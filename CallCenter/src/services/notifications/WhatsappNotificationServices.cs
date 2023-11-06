using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using CallCenter.Types;

namespace CallCenter.Services
{
    //implements Whatsapp notification services using Twilio API
    public class WhatsappNotificationServices : INotificationStrategy
    {
        private readonly string accountSid = "ACc22a1cc2695739e39421d1ede151fcab";
        private readonly string authToken = "paste here";
        private readonly string twilioPhoneNumber = "+14155238886";

        public void Notify(string message, string recipientPhoneNumber)
        {
            TwilioClient.Init(accountSid, authToken);
            var messageResource = MessageResource.Create(
                body: message,
                from: new PhoneNumber($"whatsapp:{twilioPhoneNumber}"),
                to: new PhoneNumber($"whatsapp:{recipientPhoneNumber}")
            );
        }
    }
}
