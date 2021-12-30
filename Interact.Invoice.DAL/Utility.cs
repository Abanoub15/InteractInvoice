using System;
using System.Configuration;

namespace Interact.Invoice.DAL
{
    public static class Utility
    {
        public static string GetAppUrl()
        {
            string url = ConfigurationManager.AppSettings["AppUrl"];
            return string.IsNullOrEmpty(url) ? throw new Exception("you need to add AppUrl Key in your app settings") : url;
        }
        public static string GetNotificationMessageUrl()
        {
            string url = ConfigurationManager.AppSettings["NotificationMessageEndpoint"];
            return string.IsNullOrEmpty(url) ? throw new Exception("you need to add NotificationMessageEndpoint Key in your app settings") : url;
        }
        public static string GetNotificationProgressBarUrl()
        {
            string url = ConfigurationManager.AppSettings["NotificationProgressBarEndpoint"];
            return string.IsNullOrEmpty(url) ? throw new Exception("you need to add NotificationProgressBarEndpoint Key in your app settings") : url;

        }
    }
}