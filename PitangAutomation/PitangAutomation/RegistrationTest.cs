using NLog;
using OpenQA.Selenium;
using PitangAutomation.PageModel.POM;
using PitangAutomation.TestClasses.Reports;
using PitangAutomation.Tests;

namespace PitangAutomation
{
    [TestFixture]
    public class RegistrationTest : BaseTest
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private InitialPage initialPage;
        private LoginPage loginPage;
        private RegistrationPage registrationPage;
        private ProfilePage profilePage;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            ReportGenerator.SetupExtentReport("RegistrationTestReport", "Registration Test Report");
        } 

        [SetUp]
        public void SetUp()
        {
            initialPage = new InitialPage(driver);
            loginPage = new LoginPage(driver);
            registrationPage = new RegistrationPage(driver);
            profilePage = new   (driver);
            ReportGenerator.CreateTest("TestUserRegistration");
        }

        [Test]
        public void TestUserRegistration()
        {
            try
            {

                logger.Info("Navigating to registration page.");
                initialPage.NavigateToInitialPage();
                logger.Info("Navigating to login page.");
                initialPage.AccessLoginPage();
                logger.Info("Navigating to registration page.");
                loginPage.AccessRegistrationPage();

                registrationPage.FillRegistrationFormAndSubmit("testeFirstName", "testeLastName", "testUser123", "Password!");
                logger.Info("Form submitted.");

                initialPage.AccessProfilePage();
                bool isUsernameDisplayed = profilePage.IsUsernameDisplayed("testUser123");
                Assert.IsTrue(isUsernameDisplayed, "Username was not displayed on Profile page after registration.");

                ReportGenerator.LogPass("Registration successful and username displayed on profile page.");
                // Screenshot
                driver.GetScreenshot().SaveAsFile("RegistrationPage.png");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error during registration test.");
                ReportGenerator.LogFail("Test failed: " + ex.Message);
                driver.GetScreenshot().SaveAsFile("RegistrationPageError.png");
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
