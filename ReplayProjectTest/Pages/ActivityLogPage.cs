using Xunit;

namespace ReplayProjectTest.Pages
{
    public interface IActivityLogPage
    {
        void SelectElementOnTheList(int rowNumbers);
        void RemoveSelectedElementFromTheListAndAssert(int removedElements);
    }
    public class ActivityLogPage: IActivityLogPage
    {
        private IWebDriver driver;
        private readonly IDriverFactory _driverFactory;
        private readonly IWaits _waits;
        private readonly ScenarioContext _scenarioContex;

        public ActivityLogPage(IDriverFactory driverFactory, IWaits waits, ScenarioContext scenarioContex)
        {
            _driverFactory = driverFactory;
            _waits = waits;
            _scenarioContex = scenarioContex;
            driver = _driverFactory.Driver;
        }

        IWebElement btnAction => driver.FindElement(By.XPath("//button[contains(@id,'ActionButtonHead')]"));
        IWebElement btnActionToPerform(string actioName) => driver.FindElement(
            By.XPath("//div[contains(@id,'ActionButtonHead-popup')]//div[@class='option-cell input-label ' and contains(.,'" + actioName + "')]"));
        IWebElement table => driver.FindElement(By.XPath("//table[contains(@id,'listView')]"));

        private IWebElement cournetCountofElement => driver.FindElement(
            By.XPath("//span[contains(@id,'SelectCountHead')]/following-sibling::span"));


        public void SelectElementOnTheList(int rowNumbers)
        {

            _waits.WaitForLoaderDisappear();
            _waits.WaitForElement(table);
            var rowsToDelete = TableExtension.
                                            CreateTableRowWithWebElements(table, 3, new string[]{"input","a","button"} );

            //PerformSelectOperation on first Column of the table
            foreach (var row in rowsToDelete)
            {
                row.tdDataColection[0].Element.Click();
            }
            
        }

        public void RemoveSelectedElementFromTheListAndAssert(int removedElements)
        {
            _waits.WaitForElement(cournetCountofElement);
            var initialCountofElements = Convert.ToInt32(cournetCountofElement.Text.Replace(",",""));
            
            performAction("Delete");

            _waits.WaitForLoaderDisappear();
            var actualCountofElements = Convert.ToInt32(cournetCountofElement.Text.Replace(",", ""));

            //numbers of actual elements on the list shuld be less then removed rows
             Assert.Equal(actualCountofElements, initialCountofElements - removedElements);

        }

        private void performAction(string ActionName)
        {
            _waits.WaitForElementClick(btnAction);
            _waits.WaitForElementClick(btnActionToPerform(ActionName));
            var alert = driver.SwitchTo().Alert();
            alert.Accept();
        }



    }
}
