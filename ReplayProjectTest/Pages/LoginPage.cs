using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayProjectTest.Pages
{
    public interface ILoginPage
    {
        void LoginAsAdminUser();
    }

    public class LoginPage : ILoginPage
    {
        private readonly IDriverFactory driverFactory;
        private readonly IWebDriver driver;

        public LoginPage(IDriverFactory driverFactory)
        {
            this.driverFactory = driverFactory;
            this.driver = driverFactory.Driver;
        }

        IWebElement inpUsuer => driver.FindElement(By.Id("login_user"));
        IWebElement inpPassword => driver.FindElement(By.Id("login_pass"));
        IWebElement btnLoginButton => driver.FindElement(By.Id("login_button"));

        public void LoginAsAdminUser()
        {
            inpUsuer.SendKeys("admin");
            inpPassword.SendKeys("admin");
            btnLoginButton.Click();

        }





    }
}
