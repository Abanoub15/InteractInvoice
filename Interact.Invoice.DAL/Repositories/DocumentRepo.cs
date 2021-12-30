using System.Data.Entity;
using Interact.Invoice.Core.Domain;
using Interact.Invoice.Core.Repositories;

namespace Interact.Invoice.DAL.Repositories
{
    public class DocumentRepo : Repository<Document>, IDocumentRepo
    {
        public DocumentRepo(DbContext context) : base(context)
        {
        }
        public DBContext DbContext => (DBContext)Context;

    }
}