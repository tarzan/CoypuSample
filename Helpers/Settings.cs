using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Defacto.LMS.FeatureTests.Helpers
{
   internal static class Settings
   {
      public struct User { public string username; public string password; }

      public static Coypu.Drivers.Browser Browser()
      {
         switch (ConfigurationManager.AppSettings["Default.Browser"])
         {
            case "ie":
               return Coypu.Drivers.Browser.InternetExplorer;
            case "chrome":
               return Coypu.Drivers.Browser.Chrome;
            case "firefox":
               return Coypu.Drivers.Browser.Firefox;
            default:
               return Coypu.Drivers.Browser.PhantomJS;
         }
      }

      public static string ApplicationProtocol()
      {
         return ConfigurationManager.AppSettings["Application.Protocol"] ?? "http://";
      }

      public static string ApplicationHost()
      {
         return ConfigurationManager.AppSettings["Application.Host"] ?? "selenium.defacto.nl";
      }

      public static string ApplicationName()
      {
         return ConfigurationManager.AppSettings["Application.Name"] ?? "capp11";
      }

      public static string ApplicationLoginPage()
      {
         return ConfigurationManager.AppSettings["Application.LoginPage"] ?? "/Account/Login.aspx";
      }

      public static Uri ApplicationUri()
      {
         return new Uri(ApplicationFullAddress());
      }

      public static string ApplicationFullAddress()
      {
         return string.Format("{0}{1}/{2}", ApplicationProtocol(), ApplicationHost(), ApplicationName());
      }

      public static User DefaultUser()
      {
         return new User { username = ConfigurationManager.AppSettings["Default.User.Name"], password = ConfigurationManager.AppSettings["Default.User.Password"] };
      }
   }
}
