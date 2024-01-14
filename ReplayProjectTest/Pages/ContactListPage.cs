namespace ReplayProjectTest.Pages
{
    public interface IContactListPage
    {
        void CreateContact();
        void searchAndClicEnter(string contactName);
    }

    public class ContactListPage: IContactListPage
    {
        private IWebDriver _driver;
        private readonly IDriverFactory _driverFactory;
        private readonly IWaits _waits;

        public ContactListPage(IDriverFactory driverFactory, IWaits waits)
        {
            _driverFactory = driverFactory;
            _waits = waits;
            _driver = _driverFactory.Driver;
        }

         IWebElement btnCreate => _driver.FindElement(By.XPath("//button[@class='input-button first' and @name='SubPanel_create']"));
         IWebElement btnAction => _driver.FindElement(By.XPath("//button[contains(@id,'ActionButtonHead')]"));
         IWebElement lmkName(string Name) => _driver.FindElement(By.XPath("//a[@class='listViewNameLink' and contains(.,'"+ Name + "')]"));
         IWebElement inpSearch => _driver.FindElement(By.Id("filter_text"));
         IWebElement title => _driver.FindElement(By.Id("main-title-module"));


         public void CreateContact()
         {
             _waits.WaitForLoaderDisappear();
             _waits.WaitForElement(btnAction);
             btnCreate.Click();
         }

         public void searchAndClicEnter(string Name)
         {
            _waits.WaitForLoaderDisappear();
            _waits.WaitForElement(inpSearch);
             inpSearch.SendKeys(Name);
             inpSearch.SendKeys(Keys.Enter);
            _waits.WaitForLoaderDisappear();
            _waits.WaitForElementClick(lmkName(Name)); 

        }
    }
}
