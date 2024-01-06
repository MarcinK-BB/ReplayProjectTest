using ReplayProjectTest.Pages;

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
        [Given(@"I login to a home page as a admin")]
        public void GivenILoginToAHomePageAsAAdmin()
        {
            loginPage.LoginAsAdminUser();

        }

    }
}
