using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

// Clase base que contem o WebDriver do Selenium que acessa as páginas.
// Todos os POMs (Page Object Model) utilizam o selenium, portanto, devem herdar esta classe.
namespace PitangAutomation.PageModel.POM
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait _wait => new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
