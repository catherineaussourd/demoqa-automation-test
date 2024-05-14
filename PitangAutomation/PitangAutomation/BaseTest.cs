using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace PitangAutomation.Tests
{
    public class BaseTest
    {
        public static WebDriver driver;

        static BaseTest()
        {
            var options = new ChromeOptions();
            options.AddArguments("--start-maximized", "--window-size=1920,1080"); // Define o navegador como headless "--headless",

            driver = new ChromeDriver(options);
        }
    }
}
