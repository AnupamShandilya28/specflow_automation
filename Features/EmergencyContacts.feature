Feature: EmergencyContacts
In order to reach the employee relation on emergency
As an admin
I should have access to add, edit, delete employee emergency contacts
Background:
	Given I have browser with orangehrm page
Scenario Outline: Add Emergency contact
	When I enter username as 'Admin'
	And I enter password as 'admin123'
	And I click on login
	And I click on My Info
	And I click on Emergency Contacts
	And I click on Add
	And I fill the Add Emergency Contact section
		| Name   | Relationship   | Home_Telephone   | Mobile   | Work_Telephone   |
		| <Name> | <Relationship> | <Home_Telephone> | <Mobile> | <Work_Telephone> |
	And I click on Save
	Then I verify the added name
Examples:
	| Name  | Relationship | Home_Telephone | Mobile | Work_Telephone |
	| Jimmy | brother      | 3444           | 554    | 5544           |
	| Saul  | Father       | 43444          | 3554   | 25554          |