using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PitangAutomation.PageModel.POM;
using PitangAutomation.TestClasses.POM;
using PitangAutomation.TestClasses.Reports;
using PitangAutomation.Tests;

namespace PitangAutomation.Tests
{
    [TestFixture]
    internal class BooksTest : BaseTest
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private InitialPage initialPage;
        private LoginPage loginPage;
        private ProfilePage profilePage;
        private BooksPage booksPage;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            ReportGenerator.SetupExtentReport("BooksTestReport", "Books Test Report");
        }

        [SetUp]
        public void SetUp()
        {
            initialPage = new InitialPage(driver);
            loginPage = new LoginPage(driver);
            profilePage = new ProfilePage(driver);
            booksPage = new BooksPage(driver);

            ReportGenerator.CreateTest("BooksTest");
        }

        [Test]
        public void SearchForBooks()
        {
            try
            {
                logger.Trace("Navigating to initial page.");
                initialPage.NavigateToInitialPage();
                logger.Trace("Navigating to login page.");
                initialPage.AccessLoginPage();

                loginPage.FillLoginFormAndSubmit("catherine", "Abcd1234#");
                               
                booksPage.FillSearchBookStore("JavaScript");

                // Mostra todos os livros que foram encontrados dentro do log
                ReportGenerator.LogPass(booksPage.ListBooksSearched());

                // Screenshot
                driver.GetScreenshot().SaveAsFile("SearchBooksSuccessful.png");
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error during search books test.");
                ReportGenerator.LogFail("Test failed: " + ex.Message);
                driver.GetScreenshot().SaveAsFile("SearchBooksError.png");
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
