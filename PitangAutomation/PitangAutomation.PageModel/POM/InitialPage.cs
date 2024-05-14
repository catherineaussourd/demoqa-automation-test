using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace PitangAutomation.PageModel.POM
{
    public class InitialPage : BasePage
    {
        private IWebElement LoginButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login")));
        private IWebElement ProfileLink => driver.FindElement(By.Id("item-3"));

        public InitialPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToInitialPage()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/books");
        }

        public void AccessLoginPage()
        {
            LoginButton.Click();
        }

        public void AccessProfilePage()
        {
            ProfileLink.Click();
        }
    }
}
