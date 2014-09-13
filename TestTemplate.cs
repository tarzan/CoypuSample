using Coypu;
using Defacto.LMS.FeatureTests.Helpers;
using NUnit.Framework;

namespace Defacto.LMS.FeatureTests
{
   [TestFixture]
   public abstract class TestTemplate
   {
      protected BrowserSession browser;

      [TestFixtureSetUp]
      public void FixtureSetup()
      {
         browser = new BrowserSession(new SessionConfiguration 
                              {
                                 AppHost = Settings.ApplicationHost(),
                                 Browser = Settings.Browser()
                              });
         browser.ResizeTo(1280, 1024);
         browser.Visit(Settings.ApplicationFullAddress());
      }

      [TearDown]
      public void PerTestTearDown()
      {
         TestContext context = TestContext.CurrentContext;

         if (context.Result.Status.Equals(TestStatus.Failed))
         {
            string screenshotFullPath = string.Format("{0}\\screenshot-{1}.jpg",context.TestDirectory, context.Test.FullName);
            browser.SaveScreenshot(screenshotFullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
         }
      }

      [TestFixtureTearDown]
      public void FixtureTearDown()
      {
         browser.Dispose();
      }
   }
}
