using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayProjectTest.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        protected readonly IDriverFactory _driverFactory;
        protected  readonly IWaits _waits;
        protected  readonly ScenarioContext _scenarioContex;

        public BasePage(IDriverFactory driverFactory, IWaits waits, ScenarioContext scenarioContex)
        {
            _driverFactory = driverFactory;
            _waits = waits;
            _scenarioContex = scenarioContex;
            driver = driverFactory.Driver;
        }
    }
}
