using System;
using System.Collections.Generic;
using Interact.Invoice.Common;

namespace Interact.Invoice.Core.CRMRepositories
{
    public interface ICrmHelperRepo
    {
        Guid GetCurrentUserId(string userName);
        UserRole GetRoleForCurrentUser(string userName);
    }
}