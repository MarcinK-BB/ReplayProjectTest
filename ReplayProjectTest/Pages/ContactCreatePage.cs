using OpenQA.Selenium.Interactions;
using ReplayProjectTest.Models;

namespace ReplayProjectTest.Pages
{
    public interface IContactCreatePage
    {
        void FillContact(Contact contact);

    }
    public class ContactCreatePage: BasePage, IContactCreatePage
    {

        public ContactCreatePage(IDriverFactory driverFactory, IWaits waits, ScenarioContext scenarioContex)
            : base(driverFactory, waits, scenarioContex){}


        IWebElement inpFirstName => driver.FindElement(By.Id("DetailFormfirst_name-input"));
        IWebElement inpLasttName => driver.FindElement(By.Id("DetailFormlast_name-input"));
        IWebElement Categories => driver.FindElement(By.Id("DetailFormcategories-input"));
        IWebElement btnCategoriesSearch => driver.FindElement(By.XPath("//div[@id='DetailFormcategories-input-search-text']/input"));
        IWebElement Role => driver.FindElement(By.Id("DetailFormbusiness_role-input-label"));
        IWebElement RoleItemToSelect(string role) => driver.FindElement(By.XPath("//div[@id='DetailFormbusiness_role-input-popup']//div[@class='option-cell input-label ' and contains(.,'" + role + "')]"));
        IWebElement btnSave => driver.FindElement(By.Id("DetailForm_save"));
        


        public void FillContact(Contact contact)
        {
            _waits.WaitForLoaderDisappear();
            _waits.WaitForElement(inpFirstName);
            inpFirstName.SendKeys(contact.FirstName);
            inpLasttName.SendKeys(contact.LastName);
            FillCategories(contact.Categories);
            FillRoles(contact.Role);
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.PageUp).Build().Perform();
            _waits.WaitForElementClick(btnSave);

        }
        private void FillCategories(string categories)
        {
            var categoriesList = categories.Split(',');
            foreach (var category in categoriesList)
            {
                Thread.Sleep(1000); // I have problem with that therefore I used wait:)
                _waits.WaitForElementClick(Categories);
                _waits.WaitForElement(btnCategoriesSearch);
                btnCategoriesSearch.SendKeys(category);
                btnCategoriesSearch.SendKeys(Keys.Enter);
                
            }
        }
        private void FillRoles(string roles)
        {
            _waits.WaitForElementClick(Role);
            RoleItemToSelect(roles).Click();
        }

    }
}
