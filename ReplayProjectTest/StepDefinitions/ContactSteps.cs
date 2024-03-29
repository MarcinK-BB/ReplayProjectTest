﻿using FluentAssertions;
using ReplayProjectTest.Models;
using ReplayProjectTest.Pages;
using TechTalk.SpecFlow.Assist;

namespace ReplayProjectTest.StepDefinitions
{
    [Binding]
    public sealed class ContactSteps
    {
        private readonly IContactCreatePage _contactCreatePage;
        private readonly IContactListPage _contactListPage;
        private readonly ScenarioContext _scenarioContext;
        private readonly IContactEditPage _contactEditPage;

        public ContactSteps(IDriverFactory driverFactory, IContactCreatePage contactCreatePage,
            IContactListPage contactListPage, ScenarioContext scenarioContext, IContactEditPage contactEditPage)
        {
            _contactCreatePage = contactCreatePage;
            _contactListPage = contactListPage;
            _scenarioContext = scenarioContext;
            _contactEditPage = contactEditPage;
        }

        [When(@"I Create contact with Values")]
        public void WhenICreateContactWithValues(Table table)
        {
            var contact = table.CreateInstance<Contact>();
            _contactListPage.CreateContact();
            _scenarioContext.Add("Contact",contact);
            _contactCreatePage.FillContact(contact);

        }

        [Then(@"I search for contactName: (.*) and open it")]
        public void ThenISearchForContactNameAndOpenIt(string serchPhrase)
        {
            _contactListPage.searchAndClicEnter(serchPhrase);

        }

        [Then(@"EditPage tittle should have correct text")]
        public void ThenEditPageTittleShouldHaveCorrectText()
        {
            var contact = _scenarioContext.Get<Contact>("Contact");
            _contactEditPage.EditPageTitleWithCorectTextShouldBeVisible("Contacts: "+ contact.FirstName + " " + contact.LastName);

        }

        [Then(@"Then Contact EditPage should have proper values")]
        public void ThenThenContactEditPageShouldHaveProperValues()
        {
            var adddContact = _scenarioContext.Get<Contact>("Contact");
            var actualContactEditPage = _contactEditPage.GetContactDetails();
            actualContactEditPage.Should().BeEquivalentTo(adddContact);

            //Cleaning after test - optional only  - Can be done somehow e.g in Feature  Background: 
            _contactEditPage.PerformDeleteAction("Delete");
        }

    }
}
