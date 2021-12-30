using System;
using Interact.Invoice.Core.Repositories;

namespace Interact.Invoice.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IDocumentRepo DocumentRepo { get; }

        int Complete();
    }
}
