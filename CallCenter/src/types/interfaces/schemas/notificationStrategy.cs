namespace CallCenter.Types
{
    //interface for Notification Strategy design pattern used to notify technicians via email/sms/whatsapp
    public interface INotificationStrategy
    {
        void Notify(string message, string recipientContactInfo);
    }
}
