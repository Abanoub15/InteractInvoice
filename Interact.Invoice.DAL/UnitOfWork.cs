using Interact.Invoice.Core;
using Interact.Invoice.Core.Repositories;
using Interact.Invoice.DAL.Repositories;

namespace Interact.Invoice.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _context;
        private readonly CrmConnector _cRmConnector;
        public UnitOfWork(DBContext context, CrmConnector cRmConnector)
        {
            _context = context;
            _cRmConnector = cRmConnector;
            DocumentRepo = new DocumentRepo(context);
        }

        public IDocumentRepo DocumentRepo { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
