
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
            driver = GetWebDriver();
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

    }
}
