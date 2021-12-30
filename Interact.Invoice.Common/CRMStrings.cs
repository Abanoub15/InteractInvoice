using System;
using System.Configuration;

namespace Interact.Invoice.Common
{
    public class CrmStrings
    {


        public static string GetServiceUrl()
        {
            string serviceUrl = ConfigurationManager.AppSettings["ServiceUrl"]; ;
            if (string.IsNullOrEmpty(serviceUrl))
            {
                throw new Exception("missing settings no service url review ServiceUrl is AppSettings");
            }
            return serviceUrl;
        }
        public static string GetServiceUser()
        {
            string serviceUser = ConfigurationManager.AppSettings["ServiceUser"]; ;
            if (string.IsNullOrEmpty(serviceUser))
            {
                throw new Exception("missing settings no service url review ServiceUser is AppSettings");
            }
            return serviceUser;
        }
        public static string GetServicePass()
        {
            string servicePass = ConfigurationManager.AppSettings["ServicePass"]; ;
            if (string.IsNullOrEmpty(servicePass))
            {
                throw new Exception("missing settings no service url review ServicePass is AppSettings");
            }
            return servicePass;
        }

    }
}
