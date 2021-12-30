using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace Interact.Invoice.Web
{
    public class NotificationHub : Hub
    {
        private static readonly ConnectionMapping<string> Connections = new ConnectionMapping<string>();

        public override Task OnConnected()
        {
            string userId = GetUserId();
            Connections.Add(userId, Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            string userId = GetUserId();

            Connections.Remove(userId, Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            string userId = GetUserId();

            if (!Connections.GetConnections(userId).Contains(Context.ConnectionId))
            {
                Connections.Add(userId, Context.ConnectionId);
            }

            return base.OnReconnected();
        }

        private string GetUserId()
        {
            return  Context.QueryString["UserId"];
        }

        public static IEnumerable<string> GetUserConnections(string USerId)
        {
            return Connections.GetConnections(USerId);
        }
    }
}