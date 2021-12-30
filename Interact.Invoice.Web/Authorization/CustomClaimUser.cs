using Interact.Invoice.DAL;
using System.Security.Claims;
using System.Threading;
using System.Web;

namespace Interact.Invoice.Web.Authorization
{
    public class CustomClaimUser
    {
        public static void AddNewClaim()
        {
            var crmConnector = new CrmConnector();

            ClaimsPrincipal principal = new ClaimsPrincipal(HttpContext.Current.User.Identity);

            var identity = (ClaimsIdentity)principal.Identity;

            var role = crmConnector.CrmHelper.GetRoleForCurrentUser(HttpContext.Current.User.Identity.Name);

            identity.AddClaim(new Claim("UserRole", role.ToString()));

            Thread.CurrentPrincipal = HttpContext.Current.User = principal;
        }
    }
}