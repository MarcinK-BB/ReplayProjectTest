using Xunit;

namespace ReplayProjectTest.Pages
{
    public interface IReportEditPage
    {
        void RunReport();
        void CheckResults();
    }
    public class ReportEditPage:BasePage, IReportEditPage
    {


        public ReportEditPage(IDriverFactory driverFactory, IWaits waits, ScenarioContext scenarioContex)
            : base(driverFactory, waits, scenarioContex) { }

        IWebElement FormTitle => driver.FindElement(By.XPath("//h4[@class='form-title search-title']"));
        IWebElement btnRun => driver.FindElement(By.XPath("//button[contains(@id,'FilterForm_applyButton')]"));
        IList<IWebElement> ProjectNameLinks => driver.FindElements(By.ClassName("listViewNameLink"));

        public void RunReport()
        { 
            _waits.WaitForLoaderDisappear();
            _waits.WaitForElementClick(btnRun);

            //Work aroud if page are not proper load yet
            // if(!_waits.IsElementPresent(By.XPath("//span[contains(@id,'SelectCountHead')]")))
            //    _waits.WaitForElementClick(btnRun);
        }

        public void CheckResults()
        {
            _waits.WaitForElement(By.XPath("//span[contains(@id,'SelectCountHead')]"));
            Assert.True(ProjectNameLinks.Count > 0);
        }
    }
}
