using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Interact.Invoice.Core;
using Interact.Invoice.DAL;

namespace Interact.Invoice.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            LoggerConfiguration.Configure();
        }
        protected void Application_AuthenticateRequest()
        {
            if (Request.IsAuthenticated)
            {

                try
                {
                    var crmConnector = new CrmConnector();

                    ClaimsPrincipal principal = new ClaimsPrincipal(HttpContext.Current.User.Identity);

                    var identity = (ClaimsIdentity)principal.Identity;

                    var role = crmConnector.CrmHelper.GetRoleForCurrentUser(HttpContext.Current.User.Identity.Name);

                    identity.AddClaim(new Claim("UserRole", role.ToString()));

                    Thread.CurrentPrincipal = HttpContext.Current.User = principal;
                }
                catch (Exception ex)
                {
                    StaticLogger<MvcApplication>.LogError(ex);
                }
            }
        }
    }
}
