# ReplayProjectTest
Project has added Allure report.
To run report on local machine please follow according documentation: https://allurereport.org/docs/specflow/ 

1. Install the Allure Report command-line tool, if it is not yet installed in your operating system. Note that Allure Report requires Java, see Installation

2. Generate Report
 - _**allure generate**_  - processes the test results and saves an HTML report into the allure-report directory. To view the report, use the _**allure open**_ command.
   Use this command if you need to save the report for future reference or for sharing it with colleagues.

 - _**allure serve**_ - creates the same report as allure generate but puts it into a temporary directory and starts a local web server configured to show this directory's contents. The command then automatically 
  opens the  main page of the report in a web browser.
  Use this command if you need to view the report for yourself and do not need to save it.
