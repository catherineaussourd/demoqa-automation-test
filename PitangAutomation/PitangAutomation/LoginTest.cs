using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PitangAutomation.PageModel.POM;
using PitangAutomation.TestClasses.Reports;
using PitangAutomation.Tests;

namespace PitangAutomation
{
    [TestFixture]
    public class LoginTest : BaseTest
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private InitialPage initialPage;
        private LoginPage loginPage;
        private ProfilePage profilePage;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            ReportGenerator.SetupExtentReport("LoginTestReport", "Login Test Report");
        }

        [SetUp]
        public void SetUp()
        {
            initialPage = new InitialPage(driver);
            loginPage = new LoginPage(driver);
            profilePage = new ProfilePage(driver);
            ReportGenerator.CreateTest("LoginTest");
        }

        [Test]
        public void PreRegisteredLoginTest()
        {
            try
            {
                logger.Trace("Navigating to initial page.");
                initialPage.NavigateToInitialPage();
                logger.Trace("Navigating to login page.");
                initialPage.AccessLoginPage();
                
                loginPage.FillLoginFormAndSubmit("catherine", "Abcd1234#");
                logger.Trace("Form submitted.");

                bool isUsernameDisplayed = profilePage.IsUsernameDisplayed("catherine");
                Assert.IsTrue(isUsernameDisplayed, "Username was not displayed on Profile page after registration.");

                ReportGenerator.LogPass("Login successful and username displayed on profile page.");
                // Screenshot
                driver.GetScreenshot().SaveAsFile("LoginSuccessful.png");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error during login test.");
                ReportGenerator.LogFail("Test failed: " + ex.Message);
                driver.GetScreenshot().SaveAsFile("LoginError.png");
                throw;
            }
        }

        [TearDown]
        public void TeardownTest()
        {
            ReportGenerator.SaveReport();
        }
    }
}
