Feature: TestFuture

Scenario: Create contact
	Given I login to a home page as a:
	| UserName | Password | Theme       |
	| admin    | admin    | Claro Theme |
	When I Navigate to Sales & Marketing -> Contacts
	And I Create contact with Values
	| FirstName     | LastName     | Role | Categories          |
	| TestFirstName | TestLastName | CEO  | Customers,Suppliers |
	When I Open Contacts from shortcuts
	Then I search for contactName: TestFirstName and open it
    Then Then Contact EditPage should have proper values

Scenario: Run Report
	Given I login to a home page as a:
	| UserName | Password | Theme       |
	| admin    | admin    | Claro Theme |
	When I Navigate to Reports & Settings -> Reports
	And I open Project Profitability report
	Then When I run report it should have some results

Scenario: Remove events from activity log:
    Given I login to a home page as a:
	| UserName | Password | Theme       |
	| admin    | admin    | Claro Theme |
	When I Navigate to Reports & Settings -> Activity Log 
	And I remove first 3 elements from the results
	Then Numbers of elements on the list should be less then 3


	





