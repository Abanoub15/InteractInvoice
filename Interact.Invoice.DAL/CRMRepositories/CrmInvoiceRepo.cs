using System.Threading.Tasks;
using Interact.Invoice.Core.CRMRepositories;
using Microsoft.Xrm.Sdk;

namespace Interact.Invoice.DAL.CRMRepositories
{
    public class CrmInvoiceRepo:CrmBaseRepo,ICrmInvoiceRepo
    {
        public readonly string AuditEntityName = "";

        protected CrmInvoiceRepo(IOrganizationService service) : base(service)
        {
        }
        public IOrganizationService CrmService => Service;
        public Task GetInvoice(string invoiceNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}