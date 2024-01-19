namespace ReplayProjectTest.Pages
{
    public interface IContactListPage
    {
        void CreateContact();
        void searchAndClicEnter(string contactName);
    }

    public class ContactListPage:BasePage, IContactListPage
    {
        public ContactListPage(IDriverFactory driverFactory, IWaits waits, ScenarioContext scenarioContex)
            : base(driverFactory, waits, scenarioContex) { }

        IWebElement btnCreate => driver.FindElement(By.XPath("//button[@class='input-button first' and @name='SubPanel_create']"));
         IWebElement btnAction => driver.FindElement(By.XPath("//button[contains(@id,'ActionButtonHead')]"));
         IWebElement lmkName(string Name) => driver.FindElement(By.XPath("//a[@class='listViewNameLink' and contains(.,'"+ Name + "')]"));
         IWebElement inpSearch => driver.FindElement(By.Id("filter_text"));
         IWebElement title => driver.FindElement(By.Id("main-title-module"));


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
