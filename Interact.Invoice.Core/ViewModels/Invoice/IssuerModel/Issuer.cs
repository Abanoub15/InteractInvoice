namespace Interact.Invoice.Core.ViewModels.Invoice.IssuerModel
{
    public class Issuer
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public IssuerAddress Address { get; set; }
    }
}