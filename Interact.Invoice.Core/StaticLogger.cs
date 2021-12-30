using System;
using System.Text;
using System.Web;
using log4net;

namespace Interact.Invoice.Core
{
    public class StaticLogger<T>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(T));
        public static void LogErrorDetails(Exception ex)
        {
            StringBuilder str = new StringBuilder();
            if (HttpContext.Current != null
                && HttpContext.Current.User != null
                && HttpContext.Current.User.Identity != null
                && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string username = HttpContext.Current.User.Identity.Name;
                str.AppendLine($"user-({username})");
            }
            str.AppendLine(ex.Message);
            str.AppendLine(ex.StackTrace);
            str.AppendLine("====================================================");
            Log.Error(str.ToString());
        }
        public static void LogError(string message)
        {
            StringBuilder str = new StringBuilder();
            if (HttpContext.Current != null && HttpContext.Current.User.Identity != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                string username = HttpContext.Current.User.Identity.Name;
                str.AppendLine($"user-({username})");
            }
            str.AppendLine(message);
            str.AppendLine("====================================================");
            Log.Error(str.ToString());
        }
        public static void LogError(Exception ex)
        {
            LogErrorDetails(ex.InnerException ?? ex);
        }
    }
    public class LoggerConfiguration
    {
        public static void Configure()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }

}
