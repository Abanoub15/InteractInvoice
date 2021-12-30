namespace Interact.Invoice.Core.ViewModels.Invoice.InvoiceLineModel
{
    public class InvoiceLine
    {
        public string description { get; set; }
        public string itemType { get; set; }
        public string itemCode { get; set; }
        public string unitType { get; set; }
        public decimal quantity { get; set; }
        public Value unitValue { get; set; }
        public decimal salesTotal { get; set; }
        public decimal total { get; set; }
        public decimal valueDifference { get; set; }
        public decimal totalTaxableFees { get; set; }
        public decimal netTotal { get; set; }
        public decimal itemsDiscount { get; set; }
        public Discount discount { get; set; }
        public TaxableItem[] taxableItems { get; set; }
        public string internalCode { get; set; }

    }
}