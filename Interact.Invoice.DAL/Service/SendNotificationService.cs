using System;
using Interact.Invoice.Core.IService;
using RestSharp;

namespace Interact.Invoice.DAL.Service
{
    public class SendNotificationService: ISendNotificationService
    {
        private static string _url = Utility.GetAppUrl();

        public void SendMessageToUser(string user, string message)
        {
            string url = Utility.GetAppUrl();
            string endPoint = Utility.GetNotificationMessageUrl();
            var request = new RestRequest(endPoint, Method.GET) {RequestFormat = DataFormat.Json};
            request.AddHeader("Content-Type", "application/json");

            request.AddQueryParameter("User", user);
            request.AddQueryParameter("message", message);
            RestClient client = new RestClient(url);
            client.Execute(request);

        }


        public void UpdateProgressBar(string user, decimal value)
        {
            try
            {
                string url = Utility.GetAppUrl();
                string endPoint = Utility.GetNotificationProgressBarUrl();
                var request = new RestRequest(endPoint, Method.GET);



                request.AddQueryParameter("User", user);
                request.AddQueryParameter("Value", value.ToString());
                RestClient client = new RestClient(url);
                var data = client.Execute(request);
            }
            catch (Exception ex)
            {

            }

        }
    }
}