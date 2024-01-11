namespace ReplayProjectTest.Setup
{
    [Binding]
    public sealed class Hooks
    {
       
        private readonly IDriverFactory _driverFactory;
        private readonly IApiLogin _iApiLogin;

        public Hooks(IDriverFactory driverFactory, IApiLogin iApiLogin)
        {
            this._driverFactory = driverFactory;
            _iApiLogin = iApiLogin;
        }


        [BeforeScenario("LoginUsingCredential", Order = 1)]
        public void BeforeScenario()
        {
            _driverFactory.NawigateToAppUrl();
            _driverFactory.SetUpDriver();
        }

        [BeforeScenario("LoginUsingAPI", Order = 1)]
        public void BeforeScenarioLoginAPI()
        {
            _iApiLogin.LoginApi();
        }
        

        [AfterScenario]
        public void AfterScenario()
        {
            _driverFactory.CleanUpDriver();
        }
    }
}