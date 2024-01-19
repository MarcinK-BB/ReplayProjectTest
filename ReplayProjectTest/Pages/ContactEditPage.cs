using ReplayProjectTest.Models;using ReplayProjectTest.Pages;
using Xunit;

public interface IContactEditPage
{
    void EditPageTitleWithCorectTextShouldBeVisible(string pageTitleText);
    Contact GetContactDetails();
    void PerformDeleteAction(string ActionName);
}

public class ContactEditPage:BasePage, IContactEditPage
{


    public  ContactEditPage(IDriverFactory driverFactory, IWaits waits, ScenarioContext scenarioContex)
        : base(driverFactory, waits, scenarioContex) { }


    IWebElement pageTitle => driver.FindElement(By.Id("main-title-text"));
     IWebElement header => driver.FindElement(By.Id("_form_header"));
     IWebElement Categories =>
         driver.FindElement(By.XPath("//li[contains(.,'Category')]"));
     IWebElement BuisnessRole =>
         driver.FindElement(
             By.XPath("//p[@class='form-label' and contains(.,'Business Role')]/following-sibling::div"));

     IWebElement btnDelete => driver.FindElement(By.Id("DetailForm_delete"));

    public void EditPageTitleWithCorectTextShouldBeVisible(string pageTitleText)
     {
        _waits.WaitForElement(pageTitle);
        var title = pageTitle.Text;
        Assert.Equal( pageTitleText, title);

     }

     public Contact GetContactDetails()
     {
        _waits.WaitForLoaderDisappear();
        _waits.WaitForElement(pageTitle);
         var firstName = header.Text.Split(" ")[0];
         var lastName = header.Text.Split(" ")[1];
         var categories = Categories.Text.Remove(0,10)
                                .Replace(" ","");
         var buisnessRole = BuisnessRole.Text;

         return new Contact()
         {
             FirstName = firstName,
             LastName = lastName,
             Categories = categories,
             Role = buisnessRole
         };

     }

     public void PerformDeleteAction(string ActionName)
     {
         _waits.WaitForElementClick(btnDelete);
         var alert = driver.SwitchTo().Alert();
         alert.Accept();
     }
}

