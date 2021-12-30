using Interact.Invoice.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Interact.Invoice.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            //map signalR
            app.MapSignalR();
            GlobalHost.HubPipeline.RequireAuthentication();
            
        }
    }
}
