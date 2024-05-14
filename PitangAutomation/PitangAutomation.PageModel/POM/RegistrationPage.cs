using OpenQA.Selenium;


namespace PitangAutomation.PageModel.POM
{
    public class RegistrationPage : BasePage
    {
        private IWebElement FirstnameField => driver.FindElement(By.Id("firstname"));
        private IWebElement LastnameField => driver.FindElement(By.Id("lastname"));
        private IWebElement UsernameField => driver.FindElement(By.Id("userName"));
        private IWebElement PasswordField => driver.FindElement(By.Id("password"));
        private IWebElement RegisterButton => driver.FindElement(By.Id("register"));

        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToRegistrationPage()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/register"); 
        }

        public void FillRegistrationFormAndSubmit(string firstname, string lastname, string username, string password)
        {
            FirstnameField.SendKeys(firstname);
            LastnameField.SendKeys(lastname);
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            RegisterButton.Click();
        }
    }
}
