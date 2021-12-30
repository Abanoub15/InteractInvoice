namespace Interact.Invoice.Core.ViewModels.Invoice.ReceiverModel
{
    public class Receiver
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public ReceiverAddress Address { get; set; }
    }
}