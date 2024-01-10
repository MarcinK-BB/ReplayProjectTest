using ReplayProjectTest.Pages;
using TechTalk.SpecFlow.Assist;

namespace ReplayProjectTest.StepDefinitions
{
    [Binding]
    public sealed class GeneralSteps
    {
        private readonly ILoginPage loginPage;

        public GeneralSteps(ILoginPage loginPage)
        {
            this.loginPage = loginPage;
        }
        
        [Given(@"I login to a home page as a:")]
        public void GivenILoginToAHomePageAsA(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            loginPage.LoginAsAdminUser(data.UserName,data.Password, data.Theme);
        }


    }
}
