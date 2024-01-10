using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayProjectTest.Pages
{
    public class ReportListPage: IReportListPage
    {
        IWebDriver driver;
        private readonly IDriverFactory _driverFactory;
        private readonly IWaits _waits;

        public ReportListPage(IDriverFactory driverFactory, IWaits waits)
        {
            _driverFactory = driverFactory;
            _waits = waits;
            driver = _driverFactory.Driver;
        }
        IWebElement lmkName(string Name) => driver.FindElement(By.XPath("//a[@class='listViewNameLink' and contains(.,'" + Name + "')]"));

        IWebElement inpSearch => driver.FindElement(By.Id("filter_text"));

        IWebElement btnAction => driver.FindElement(By.XPath("//button[contains(@id,'ActionButtonHead')]"));

        public void searchAndClicEnter(string Name)
        {

            _waits.WaitForElement(inpSearch);
            Thread.Sleep(1000);
            inpSearch.SendKeys(Name);
            inpSearch.SendKeys(Keys.Enter);
            _waits.WaitForElementClick(lmkName(Name));
        }
    }

    public interface IReportListPage
    {
        void searchAndClicEnter(string Name);
    }
}
