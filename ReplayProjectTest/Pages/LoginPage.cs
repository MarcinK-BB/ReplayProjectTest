namespace ReplayProjectTest.Pages
{
    public interface ILoginPage
    {
        void LoginAsAdminUser(string login, string password, string scheme);
    }

    public class LoginPage : ILoginPage
    {
        private readonly IDriverFactory driverFactory;
        private readonly FeatureContext _featureContext;
        private readonly IWebDriver driver;

        public LoginPage(IDriverFactory driverFactory, FeatureContext featureContext)
        {
            this.driverFactory = driverFactory;
            _featureContext = featureContext;
            this.driver = driverFactory.Driver;
        }

        IWebElement inpUsuer => driver.FindElement(By.Id("login_user"));
        IWebElement inpPassword => driver.FindElement(By.Id("login_pass")); IWebElement selTheme => driver.FindElement(By.Id("login_theme"));
        IWebElement btnLoginButton => driver.FindElement(By.Id("login_button"));

        public void LoginAsAdminUser(string login, string password, string scheme)
        {
            inpUsuer.SendKeys(login);
            inpPassword.SendKeys(password);
            selTheme.SelectByText(scheme);
            btnLoginButton.Click();
        }

    }
}
