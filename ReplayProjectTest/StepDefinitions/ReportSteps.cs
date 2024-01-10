using ReplayProjectTest.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayProjectTest.StepDefinitions
{
    [Binding]
    public sealed class ReportSteps
    {
        IWebDriver driver;
        private readonly IDriverFactory _driverFactory;
        private readonly IReportListPage _reportListPage;
        private readonly IReportEditPage _reportEditPage;


        public ReportSteps(IDriverFactory driverFactory, IReportListPage reportListPage, IReportEditPage reportEditPage)
        {
            _driverFactory = driverFactory;
            _reportListPage = reportListPage;
            _reportEditPage = reportEditPage;
            driver = _driverFactory.Driver;
        }

        [When(@"I open (.*) report")]
        public void WhenIOpenReport(string reportName)
        {
            _reportListPage.searchAndClicEnter(reportName);
        }

        [Then(@"When I run report it should have some results")]
        public void ThenWhenIRunReportItShouldHaveSomeResults()
        {
            _reportEditPage.RunReport();
            _reportEditPage.CheckResults();
        }

   


    }
}
