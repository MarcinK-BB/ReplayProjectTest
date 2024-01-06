namespace ReplayProjectTest.Drivers
{
    public interface IDriverFactory
    {
        IWebDriver Driver { get; }
        void NawigateToAppUrl();

        void Dispose();
    }
}