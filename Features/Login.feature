Feature: Login
In order to maintain the employee record
As a user
I want to login into portal
Scenario: Valid Credential
Given I have browser with orangehrm page
	When I enter username as 'Admin'
	And I enter password as 'admin123'
	And I click on login
Then I should navigate to 'PIM' dashboard screen+






