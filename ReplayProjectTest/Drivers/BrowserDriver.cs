using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Firefox;

namespace ReplayProjectTest.Drivers
{
    public class BrowserDriver : IBrowserDriver
    {
        public IWebDriver GetChromDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            return new ChromeDriver();
        }

        public IWebDriver GetFirefoxDriver()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver();
        }

    }
    public enum BrowserType
    {
        Chrome,
        Firefox
    }
}
