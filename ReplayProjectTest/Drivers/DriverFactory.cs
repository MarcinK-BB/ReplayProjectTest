
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using ReplayProjectTest.Setup;

namespace ReplayProjectTest.Drivers
{
    public class DriverFactory : IDriverFactory
    {
        IWebDriver driver;
        private readonly TestSettings testSettings;
        private readonly IBrowserDriver browserDriver;

        //DI is happening
        public DriverFactory(TestSettings testSettings, IBrowserDriver browserDriver)
        {
            this.testSettings = testSettings;
            this.browserDriver = browserDriver;
            if (testSettings.ExecutionType == ExecutionType.Local)
                driver = GetWebDriver();
            else
                driver = new RemoteWebDriver(testSettings.SeleniumGridUrl, GetBrowserOptions());

        }

        public IWebDriver Driver => driver;
        public void NawigateToAppUrl() => driver.Navigate().GoToUrl(testSettings.ApplicationUrl);

        public void SetUpDriver()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Convert.ToInt32(testSettings.ImplicitlyWait));
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Convert.ToInt32(testSettings.PageLoadTimeout));
        }

        public void CleanUpDriver() => driver.Quit();

        private IWebDriver GetWebDriver()
        {
            return testSettings.BrowserType switch
            {
                BrowserType.Chrome => browserDriver.GetChromDriver(),
                BrowserType.Firefox => browserDriver.GetFirefoxDriver(),
                _ => browserDriver.GetChromDriver()
            };
        }
        private dynamic GetBrowserOptions()
        {
            switch (testSettings.BrowserType)
            {
                case BrowserType.Firefox:
                {
                    var firefoxOption = new FirefoxOptions();
                    firefoxOption.AddAdditionalOption("se:recordVideo", true);
                    return firefoxOption;
                }
                case BrowserType.Chrome:
                {
                    var chromeOption = new ChromeOptions();
                    chromeOption.AddAdditionalOption("se:recordVideo", true);
                    return chromeOption;
                }
                default:
                    return new ChromeOptions();
            }
        }

    }
}
