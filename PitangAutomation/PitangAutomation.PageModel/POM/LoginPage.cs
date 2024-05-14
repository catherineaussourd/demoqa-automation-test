using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Xml.Linq;

namespace PitangAutomation.PageModel.POM
{
    public class LoginPage : BasePage
    {
        private IWebElement UsernameField => driver.FindElement(By.Id("userName"));
        private IWebElement PasswordField => driver.FindElement(By.Id("password"));
        private IWebElement NewUserButton => driver.FindElement(By.Id("newUser"));
        private IWebElement LoginButton => driver.FindElement(By.Id("login"));

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void AccessRegistrationPage()
        {
            NewUserButton.Click();
        }

        public void FillLoginFormAndSubmit(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);

            Actions actions = new Actions(driver);
            actions.MoveToElement(LoginButton).Click().Perform();
        }
    }
}
