using OpenQA.Selenium.Interactions;
using ReplayProjectTest.Setup;

namespace ReplayProjectTest.Pages
{
    public interface IHomePage
    {
        void openMenu(string mainMenu, string subMenu);
        void openShortCuts(string name);
    }

    public class HomePage: BasePage, IHomePage
    {
        private readonly TestSettings _settings;

        public HomePage(IDriverFactory driverFactory, IWaits waits, ScenarioContext scenarioContex, TestSettings settings)
            :base(driverFactory, waits, scenarioContex)
        {
            _settings = settings;
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

           if(_settings.BrowserType == BrowserType.Firefox)
                builder.MoveToElement(mainMenuItem(mainMenu)).
                    Click().Build().Perform();
           else
               builder.MoveToElement(mainMenuItem(mainMenu)).
                   Build().Perform();

           _waits.WaitForLoaderDisappear();
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
