using System;
using System.Linq;
using Interact.Invoice.Common;
using Interact.Invoice.Core;
using Interact.Invoice.Core.CRMRepositories;
using Microsoft.Xrm.Sdk;

namespace Interact.Invoice.DAL.CRMRepositories
{
    public class CrmHelperRepo : CrmBaseRepo, ICrmHelperRepo
    {
        public CrmHelperRepo(IOrganizationService service) : base(service)
        {
        }

        public Guid GetCurrentUserId(string userName)
        {
            Guid userId = Guid.Empty;
            try
            {
                //userName = "INTERACTTS\\Abanoub.Mounir";
                var res = GetDataFromEntityByOneFieldEquality("systemuser", "domainname", userName);
                if (res.Count > 0)
                {
                    userId = res[0].GetAttributeValue<Guid>("systemuserid");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                StaticLogger<CrmHelperRepo>.LogError(e);
                throw e;
            }
            return userId;
        }

        public UserRole GetRoleForCurrentUser(string userName)
        {
            if (string.IsNullOrEmpty(userName)) return UserRole.User;
            try
            {
                //userName = "INTERACTTS\\Abanoub.Mounir";
                var user = GetDataFromEntityByOneFieldEquality("systemuser", "domainname", userName).FirstOrDefault();
                if (user != null)
                {
                    var adminRole = GetDataFromEntityByOneFieldEqualityLink("systemuserroles", "systemuserid", user.Id);
                    if (adminRole.Count > 0) return UserRole.Admin;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                StaticLogger<CrmHelperRepo>.LogError(e);
            }
            return UserRole.User;
        }
    }
}