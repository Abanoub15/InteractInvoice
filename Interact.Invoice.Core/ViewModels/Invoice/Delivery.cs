namespace Interact.Invoice.Core.ViewModels.Invoice
{
    public class Delivery
    {
        public string approach { get; set; }
        public string packaging { get; set; }
        public string dateValidity { get; set; }
        public string exportPort { get; set; }
        public string countryOfOrigin { get; set; }
        public decimal grossWeight { get; set; }
        public decimal netWeight { get; set; }
        public string terms { get; set; }
    }
}