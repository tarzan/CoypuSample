using Coypu;
using OpenQA.Selenium;

namespace Defacto.LMS.FeatureTests.Helpers
{
   public static class DefaultActions
   {
      public static void Login(this BrowserSession browser, string userName, string passWord)
      {
         if (browser.SignedIn())
            return;

         browser.Visit(Settings.ApplicationFullAddress() + Settings.ApplicationLoginPage());
         browser.FillIn("UserName").With(userName);
         browser.FillIn("Password").With(passWord);
         browser.FindField("Password").SendKeys(Keys.Return);
      }

      public static void Logout(this BrowserSession browser)
      {
         if (!browser.SignedIn())
            return;

         browser.ClickLink("Uitloggen", Options.First);
      }

      public static bool SignedIn(this BrowserSession browser)
      {
         var signedIn = new State(() => browser.HasContent("Ingelogd"));
         var signedOut = new State(() => browser.HasContent("Inloggen"));

         return (browser.FindState(signedIn, signedOut) == signedIn);
      }
   }
}
