namespace Interact.Invoice.Core.ViewModels.Invoice.InvoiceLineModel
{
    public class TaxableItem
    {
        public string taxType { get; set; }
        public decimal amount { get; set; }
        public string subType { get; set; }
        public decimal rate { get; set; }
    }
}