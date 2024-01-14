namespace ReplayProjectTest.Pages
{
    public interface ILoginPage
    {
        void LoginAsAdminUser(string login, string password, string scheme);
    }

    public class LoginPage : ILoginPage
    {
        private readonly IDriverFactory driverFactory;
        private readonly IWaits  _waits;
        private readonly IWebDriver driver;

        public LoginPage(IDriverFactory driverFactory, IWaits waits)
        {
            this.driverFactory = driverFactory;
            _waits = waits;
            this.driver = driverFactory.Driver;
        }

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
