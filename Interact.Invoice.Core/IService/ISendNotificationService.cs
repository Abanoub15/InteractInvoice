namespace Interact.Invoice.Core.IService
{
    public interface ISendNotificationService
    {
        void SendMessageToUser(string user, string message);
        void UpdateProgressBar(string user, decimal value);
    }
}