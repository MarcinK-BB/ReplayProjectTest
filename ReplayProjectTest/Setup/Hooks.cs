﻿
using ReplayProjectTest.Drivers;

namespace ReplayProjectTest.Setup
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IDriverFactory _driverFactory;

        public Hooks(IDriverFactory driverFactory)
        {
            this._driverFactory = driverFactory;
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
            _driverFactory.NawigateToAppUrl();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverFactory.Dispose();
        }
    }
}