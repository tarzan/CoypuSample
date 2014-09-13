using Coypu;
using Defacto.LMS.FeatureTests.Helpers;
using NUnit.Framework;

namespace Defacto.LMS.FeatureTests.Tests
{
   [TestFixture]
   public class UserLogin : TestTemplate
   {
      [SetUp]
      public void SetUp()
      {
         browser.Logout();
      }

      [Test]
      public void LoginDefaultUser()
      {
         browser.Login(Settings.DefaultUser().username, Settings.DefaultUser().password);
         Assert.That(browser.SignedIn());
      }

      [Test]
      public void LogoutDefaultUser()
      {
         browser.Login(Settings.DefaultUser().username, Settings.DefaultUser().password);
         browser.Logout();
         Assert.That(!browser.SignedIn());
      }
   }
}
