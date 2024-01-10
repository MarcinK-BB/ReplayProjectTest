using ReplayProjectTest.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplayProjectTest.StepDefinitions
{
    [Binding]
    public sealed class HomePageSteps
    {
        private readonly IHomePage _homePage;


        public HomePageSteps(IHomePage homePage)
        {
            this._homePage = homePage;
        }

        [When(@"I Navigate to (.*) -> (.*)")]
        public void WhenINavigateTo_(string mainMenuItem, string subMenuItem)
        {
            _homePage.openMenu(mainMenuItem, subMenuItem);
        }

        [When(@"I Open (.*) from shortcuts")]
        public void WhenIOpenFromShortcuts(string name)
        {
            _homePage.openShortCuts(name);
        }




    }
}
