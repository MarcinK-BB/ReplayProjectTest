using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Firefox;
using ReplayProjectTest.Setup;

namespace ReplayProjectTest.Drivers
{
    public class BrowserDriver : IBrowserDriver
    {
        private readonly TestSettings _testSettings;

        public BrowserDriver(TestSettings testSettings)
        {
            _testSettings = testSettings;
        }
        public IWebDriver GetChromDriver()
        {
            var option = new ChromeOptions();
            new DriverManager().SetUpDriver(new ChromeConfig(), version: "Latest");
            if (_testSettings.UseHeadless)
            {
                
                option.AddArgument("--headless");
                option.AddArgument("window-size=1920,1080");

            }
            return new ChromeDriver(option);
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
