Feature: Employee

In order to add employee to the portal 
as a admin
I want to add records  to the portal

Scenario: Add Employee
	Given I have browser with orangehrm page
	When I enter username as 'Admin'
	And I enter password as 'admin123'
	And I click on login
	And I click on PIM
	And I click on Add Employee
	And I add all details
		| firstname | middle_name | last_name | employee_id | toggle_login_details | username | password    | confirm_password | status   |
		| Anupam    | abc         | Shandilya | 1           | on                   | anup28   | Welcome@123 | Welcome@123      | disabled |
	And I click on save option
	Then I should navigate to personal details

