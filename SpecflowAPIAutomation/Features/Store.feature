Feature: StoreShop
In order to create an environment for managing pet shop
As a user
I want to handle the orders

#complete the scenario and connect with automation script 
Scenario: Find Purchase Order By ID
Given I have base url 'https://petstore.swagger.io/v2/' and resourse 'store/order/102'
When I do the Get request 
Then I should get the response as 200


Scenario: Find Purchase Order By Non-Existing ID
Given I have base url 'https://petstore.swagger.io/v2/' and resourse 'store/order/102'
When I do the Get request 
Then I should get the response as 404