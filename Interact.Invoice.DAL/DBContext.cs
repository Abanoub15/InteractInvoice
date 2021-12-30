using System.Data.Entity;
using Interact.Invoice.Core.Domain;

namespace Interact.Invoice.DAL
{
    public class DBContext : DbContext
    {
        public DBContext() : base("name=ContextDbContainer")
        {
        }
        public DbSet<Document> Documents { get; set; }
    }
}

