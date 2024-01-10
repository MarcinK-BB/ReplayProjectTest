using ReplayProjectTest.Pages;

namespace ReplayProjectTest.StepDefinitions
{
    [Binding]
    public sealed class ActivityLogSteps
    {
        private readonly IActivityLogPage _activityLogPage;

        public ActivityLogSteps(IActivityLogPage activityLogPage)
        {
            _activityLogPage = activityLogPage;
        }

        [When(@"I remove first (.*) elements from the results")]
        public void WhenIRemoveFirstElementsFromTheResults(int RowNumber)
        {
            _activityLogPage.SelectElementOnTheList(RowNumber);
        }


        [Then(@"Numbers of elements on the list should be less then (.*)")]
        public void ThenNumbersOfElementsOnTheListShouldBeLessThen(int number)
        {
            _activityLogPage.RemoveSelectedElementFromTheListAndAssert(3);
        }
    }
}
