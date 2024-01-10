using OpenQA.Selenium.Support.UI;

namespace ReplayProjectTest.Extensions
{
    public static class WebElementExtension
    {
        public static void EnterText(this IWebElement element, string text)
        {
            try
            {
                element.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            element.SendKeys(text);
        }

        public static void SelectByText(this IWebElement element, string text)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(text);

        }
    }
}
