using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace PitangAutomation.PageModel.POM
{
    public class ProfilePage : BasePage
    {
        private IWebElement UsernameLabel => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("userName-value")));

        public ProfilePage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsUsernameDisplayed(string expectedUsername)
        {
            return UsernameLabel.Text.Contains(expectedUsername);
        }

    }
}
