using ReplayProjectTest.Pages;

namespace ReplayProjectTest.StepDefinitions
{
    [Binding]
    public sealed class ReportSteps
    {
        private readonly IReportListPage _reportListPage;
        private readonly IReportEditPage _reportEditPage;


        public ReportSteps(IDriverFactory driverFactory, IReportListPage reportListPage, IReportEditPage reportEditPage)
        {

            _reportListPage = reportListPage;
            _reportEditPage = reportEditPage;
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
