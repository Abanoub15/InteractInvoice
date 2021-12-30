using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Interact.Invoice.Web.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AdminAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {




        //public override void OnAuthorization(AuthorizationContext filterContext)
        //{
        //    var user = filterContext.HttpContext.User;

        //    if (!user.Identity.IsAuthenticated)
        //    {
        //        return;
        //    }

        //    if (((System.Security.Claims.ClaimsIdentity)user.Identity).Claims.FirstOrDefault(e => e.Value == "Admint")==null)
        //    {
        //        filterContext.Result = new HttpUnauthorizedResult();
        //        //return;
        //    }
        //}
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = httpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                return false;
            }
            if (((System.Security.Claims.ClaimsIdentity)user.Identity).Claims.FirstOrDefault(e => e.Value == "Admin") == null)
            {
                return false;
                //return;
            }
            return base.AuthorizeCore(httpContext);
        }
    }
}