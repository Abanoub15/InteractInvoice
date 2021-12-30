using System;
using Interact.Invoice.Common;

namespace Interact.Invoice.Core.Domain
{
    public class Document
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime PostedOn { get; set; }
        public Guid? InvoiceDocumentId { get; set; }
        public string InvoiceNumber { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
    }
}