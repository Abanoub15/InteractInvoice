using System.Threading.Tasks;

namespace Interact.Invoice.Core.CRMRepositories
{
    public interface ICrmInvoiceRepo
    {
        Task GetInvoice(string invoiceNumber);
    }
}