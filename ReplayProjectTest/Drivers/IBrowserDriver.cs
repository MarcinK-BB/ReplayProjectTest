namespace ReplayProjectTest.Drivers
{
    public interface IBrowserDriver
    {
        IWebDriver GetChromDriver();
        IWebDriver GetFirefoxDriver();
    }
}