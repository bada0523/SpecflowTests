Feature: Seller -> Add description on my profile Details
Priority: Major
As a Seller
I want the feature to add description Profile Details
So that
The people seeking for some description can look into my details.

Background:
	Given I clicked the pencil icon next to description under profile page

@mytag
#Writing my description
Scenario: Check if user could able to write a description
	When I write about my information
	Then that information should be displayed on description section

#Negative for description
Scenario: Check possibility to make a blank on text area
	When I make a blank on the text area
	Then it should be added and displayed alert message

Scenario: Check possibility to input maximum number of area
	When I entered 1000 words on the text area
	Then it shoud be not added and displayed alert message

Scenario: Check possibility to input different language on the text area
	When I enter Korean words on the area
	Then it should be not added and displayed alert message

Scenario: Check possibility to copy and paste on the text area
	When I copy words and paste on the text area
	Then it should be added

Scenario: Check possibility to input uppercase and lowercase together on the text area
	When I enter uppercase and lowercase on the text area
	Then it should be added

Scenario: Check possibility to input special characters on thext area
	When I enter special characters on text area
	Then it should be added