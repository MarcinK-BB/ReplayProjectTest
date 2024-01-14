using OpenQA.Selenium.Interactions;
using ReplayProjectTest.Setup;

namespace ReplayProjectTest.Pages
{
    public interface IHomePage
    {
        void openMenu(string mainMenu, string subMenu);
        void openShortCuts(string name);
    }

    public class HomePage: IHomePage
    {
        private readonly IDriverFactory driverFactory;
        private readonly IWaits _waits;
        private readonly TestSettings _settings;
        private readonly IWebDriver driver;

        public HomePage(IDriverFactory driverFactory, IWaits waits,TestSettings settings)
        {
            this.driverFactory = driverFactory;
            this._waits = waits;
            _settings = settings;
            this.driver = driverFactory.Driver;
        }

        IWebElement mainMenuItem(string manuName) => driver.FindElement(By.XPath("//div[@class='menu-label' and contains(.,'" + manuName + "')]"));
        IWebElement subMenuItem(string subMenu) => driver.FindElement(By.XPath("//div[contains(@id,'menu-source')]//div[@class='option-cell input-label ' and contains(.,'" + subMenu + "')]"));
        IWebElement shortCuts(string name) => driver.FindElement(By.XPath(
            "//div[@id='page-shortcuts']//div[@class='option-cell input-label ' and contains(.,'"+ name + "')]"));

        public void openMenu(string mainMenu, string subMenu)
        {
            _waits.WaitForLoaderDisappear();
            _waits.WaitForElement(mainMenuItem(mainMenu));
            Actions builder = new Actions(driver);
            builder.MoveToElement(mainMenuItem(mainMenu)).
                Build().Perform();
           if(_settings.BrowserType == BrowserType.Firefox)
            mainMenuItem(mainMenu).Click();
            _waits.WaitForElement(subMenuItem(subMenu));
            subMenuItem(subMenu).Click();
        }

        public void openShortCuts(string name)
        {
            _waits.WaitForLoaderDisappear();
            _waits.WaitForElementClick(shortCuts(name));
        }



    }

 
}
