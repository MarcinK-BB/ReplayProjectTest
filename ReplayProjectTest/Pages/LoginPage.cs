namespace ReplayProjectTest.Pages
{
    public interface ILoginPage
    {
        void LoginAsAdminUser(string login, string password, string scheme);
    }

    public class LoginPage : BasePage, ILoginPage
    {


        public LoginPage(IDriverFactory driverFactory, IWaits waits, ScenarioContext scenarioContex)
            : base(driverFactory, waits, scenarioContex) { }

        IWebElement inpUsuer => driver.FindElement(By.Id("login_user"));
        IWebElement inpPassword => driver.FindElement(By.Id("login_pass")); IWebElement selTheme => driver.FindElement(By.Id("login_theme"));
        IWebElement btnLoginButton => driver.FindElement(By.Id("login_button"));

        public void LoginAsAdminUser(string login, string password, string scheme)
        {
            _waits.WaitForElement(inpUsuer);
            inpUsuer.SendKeys(login);
            inpPassword.SendKeys(password);
            selTheme.SelectByText(scheme);
            btnLoginButton.Click();
        }

    }
}
