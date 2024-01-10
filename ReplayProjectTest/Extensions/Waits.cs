using OpenQA.Selenium.Support.UI;
using ReplayProjectTest.Setup;
using SeleniumExtras.WaitHelpers;
using System.Security.Cryptography;

namespace ReplayProjectTest.Extensions
{
    public interface IWaits
    {
        void WaitForElement(IWebElement element, int timeOut = 10);
        void WaitForElement(By element, int timeOut = 10);
        void WaitForElementClick(IWebElement element, int timeOut = 10);
        bool IsElementPresent(By by);
        void WaitForLoaderDisappear();
    }

    public class Waits : IWaits
    {
    
        private readonly IWebDriver driver;
        private readonly IDriverFactory _driverFactory;
        private readonly TestSettings _testSettings;

        public Waits(IDriverFactory driverFactory,  TestSettings testSettings)
        {
            _driverFactory = driverFactory;
            _testSettings = testSettings;
            driver = _driverFactory.Driver;
        }

        public void WaitForElement(IWebElement element, int timeOut = 10)
        {
          
                DateTime now = DateTime.Now;
                while (DateTime.Now < now.AddSeconds(timeOut))
                {
                    try
                    {
                        new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut)).Until(
                            ExpectedConditions.ElementToBeClickable(element));

                        return;
                    }

                    catch (ElementClickInterceptedException)
                    {

                    }
                    catch (StaleElementReferenceException)
                    {
                    }
                }

                throw new Exception($"Unable to click element  within {timeOut}s.");
  
        }


        public void WaitForElement(By element, int timeOut = 10)
        {

            DateTime now = DateTime.Now;
            while (DateTime.Now < now.AddSeconds(timeOut))
            {
                try
                {
                    new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut)).Until(
                        ExpectedConditions.ElementToBeClickable(element));

                    return;
                }

                catch (ElementClickInterceptedException)
                {
                }
                catch (StaleElementReferenceException)
                {
                }
            }

            throw new Exception($"Unable to click element: {element}  within {timeOut}s.");

        }

        public void WaitForElementClick(IWebElement element, int timeOut = 10)
        {

            DateTime now = DateTime.Now;
            while (DateTime.Now < now.AddSeconds(timeOut))
            {
                try
                {
                    new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut)).Until(
                        ExpectedConditions.ElementToBeClickable(element)).Click();

                    return;
                }

                catch (ElementClickInterceptedException)
                {

                }
                catch (StaleElementReferenceException)
                {
                }
            }

            throw new Exception($"Unable to click element  within {timeOut}s.");

        }

        public bool IsElementPresent(By by)
        {

            driver.Manage().Timeouts().Equals(TimeSpan.FromMilliseconds(5000));
            try
            {

                driver.FindElement(by);
                driver.Manage().Timeouts().Equals(TimeSpan.FromSeconds(Convert.ToInt32(_testSettings.ImplicitlyWait)));
                return true;
            }
            catch (NoSuchElementException e)
            {
                driver.Manage().Timeouts().Equals(TimeSpan.FromSeconds(Convert.ToInt32(_testSettings.ImplicitlyWait)));
                return false;
            }
        }

        public void WaitForLoaderDisappear()
        {
            var timeouts = driver.Manage().Timeouts();
            timeouts.ImplicitWait = TimeSpan.FromSeconds(5);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("ajaxStatusDiv")));
            timeouts.ImplicitWait = TimeSpan.FromSeconds(Convert.ToInt32(_testSettings.ImplicitlyWait));
        }
    }

   
}
