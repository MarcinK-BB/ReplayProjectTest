namespace ReplayProjectTest.Pages
{
    public interface IReportListPage
    {
        void searchAndClicEnter(string Name);
    }
    public class ReportListPage: BasePage,IReportListPage
    {
        IWebDriver driver;
        private readonly IDriverFactory _driverFactory;
        private readonly IWaits _waits;

        public ReportListPage(IDriverFactory driverFactory, IWaits waits, ScenarioContext scenarioContex)
            : base(driverFactory, waits, scenarioContex) { }
        IWebElement lmkName(string Name) => driver.FindElement(By.XPath("//a[@class='listViewNameLink' and contains(.,'" + Name + "')]"));

        IWebElement inpSearch => driver.FindElement(By.Id("filter_text"));

        IWebElement btnAction => driver.FindElement(By.XPath("//button[contains(@id,'ActionButtonHead')]"));

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
