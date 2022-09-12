Feature: Login
In order to maintain the employee record
As a user
I want to login into portal
Scenario: Valid Credential
Given I have browser with orangehrm page
When I provide username as 'Admin'
And I provide password as 'admin123'
And I Click on login
Then I should navigate to 'PIM' dashboard screen+






