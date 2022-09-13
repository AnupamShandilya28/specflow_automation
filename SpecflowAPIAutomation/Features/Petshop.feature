Feature: PetShop
In order to create an environment for managing pet shop
As a user
I want to create, edit, delete, get pet details 

Scenario: Find Pet By PetId
Given I have base url 'https://petstore.swagger.io/v2/' and resourse 'pet/102'
When I do the Get request 
Then I should get the response as 200
And I should get the pet details in json format 

Scenario: Find Pet By Invalid PetId
Given I have base url 'https://petstore.swagger.io/v2/' and resourse 'pet/-102'
When I do the Get request 
Then I should get the response as 400
And I should get message as 'Invalid ID supplied'

Scenario: Find pet by non-existing petId
Given I have base url 'https://petstore.swagger.io/v2/' and resourse 'pet/1002'
When I do the Get request 
Then I should get the response as 404
And I should get message as 'Pet not found'

Scenario: Delete pet by petId
Given I have base url 'https://petstore.swagger.io/v2/' and resourse 'pet/1022'
And I need add api_key 'AK888' in the header
When I do the Delete request
Then I should get the response as 200

Scenario: Delete pet by Invalid petId
Given I have base url 'https://petstore.swagger.io/v2/' and resourse 'pet/-102'
And I need add api_key 'AK888' in the header
When I do the Delete request
Then I should get the response as 400
And I should get message as 'Invalid ID supplied'

Scenario: Delete pet by non-existing petId
Given I have base url 'https://petstore.swagger.io/v2/' and resourse 'pet/1502'
And I need add api_key 'AK888' in the header
When I do the Delete request
Then I should get the response as 404
And I should get message as 'Pet not found'