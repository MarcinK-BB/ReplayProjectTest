using ReplayProjectTest.Setup;

namespace ReplayProjectTest.Setup
{
    public class TestSettings
    {
        public BrowserType BrowserType { get; set; }
        public Uri ApplicationUrl { get; set; }
        public bool UseHeadless { get; set; }
        public int  ImplicitlyWait { get; set; }
        public int PageLoadTimeout { get; set; }

        public Uri SeleniumGridUrl { get; set; }

        public ExecutionType ExecutionType { get; set; }
    }



        public enum ExecutionType
        {
            Local,
            Remote
        }
    


}
