using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ReplayProjectTest.Pages
{
    public class ReportEditPage: IReportEditPage
    {
        private IWebDriver driver;
        private readonly IDriverFactory _driverFactory;
        private readonly IWaits _waits;

        public ReportEditPage(IDriverFactory driverFactory, IWaits waits)
        {
            _driverFactory = driverFactory;
            _waits = waits;
            driver = _driverFactory.Driver;
        }

        IWebElement FormTitle => driver.FindElement(By.XPath("//h4[@class='form-title search-title']"));
        IWebElement btnRun => driver.FindElement(By.XPath("//button[contains(@id,'FilterForm_applyButton')]"));
        IList<IWebElement> ProjectNameLinks => driver.FindElements(By.ClassName("listViewNameLink"));

        public void RunReport()
        { 
            _waits.WaitForElementClick(btnRun);
            if(!_waits.IsElementPresent(By.XPath("//span[contains(@id,'SelectCountHead')]")))
               _waits.WaitForElementClick(btnRun);
        }

        public void CheckResults()
        {
            _waits.WaitForElement(By.XPath("//span[contains(@id,'SelectCountHead')]"));
            Assert.True(ProjectNameLinks.Count > 0);
        }
    }

    public interface IReportEditPage
    {
        void RunReport();
        void CheckResults();
    }
}
