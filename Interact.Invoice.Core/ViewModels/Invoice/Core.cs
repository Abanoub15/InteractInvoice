using System;
using Interact.Invoice.Core.ViewModels.Invoice.InvoiceLineModel;
using Interact.Invoice.Core.ViewModels.Invoice.IssuerModel;
using Interact.Invoice.Core.ViewModels.Invoice.ReceiverModel;

namespace Interact.Invoice.Core.ViewModels.Invoice
{
    public class Core
    {
        public Issuer issuer { get; set; }
        public Receiver receiver { get; set; }
        public string documentType { get; set; }
        public string documentTypeVersion { get; set; }
        public DateTime dateTimeIssued { get; set; }
        public string taxpayerActivityCode { get; set; }
        public string internalId { get; set; }
        public string purchaseOrderReference { get; set; }
        public string purchaseOrderDescription { get; set; }
        public string salesOrderReference { get; set; }
        public string salesOrderDescription { get; set; }
        public string proformaInvoiceNumber { get; set; }
        public Payment payment { get; set; }
        public Delivery delivery { get; set; }
        public InvoiceLine[] invoiceLines { get; set; }
        public decimal totalSalesAmount { get; set; }
        public decimal totalDiscountAmount { get; set; }
        public decimal netAmount { get; set; }
        public TaxTotal[] taxTotals { get; set; }
        public decimal extraDiscountAmount { get; set; }
        public decimal totalItemsDiscountAmount { get; set; }
        public decimal totalAmount { get; set; }
        public Signature[] signatures { get; set; }
    }
}