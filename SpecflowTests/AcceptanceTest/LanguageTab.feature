Feature: Seller -> Add languages on my profile Details
Priority: Major
As a Seller
I want the feature to add languages Profile Details
So that
The people seeking for some languages can look into my details.

#Add languages
Scenario Outline: Check if user could able to add languages
	Given I clicked on the Langauge tab under Profile page
	When I add new languages <language>
	Then those languages <language> should be displayed on my listings

	Examples:
		| language |
		| English  |
		| Korean   |
		| Chinese  |

#Editing language
Scenario: Check if user could able to edit a language
	Given I clicked the pencil icon on my listings under Profile page
	When I edit a skill
	Then that updated language should be displayed on my listings

#deleting language
Scenario: Check if user could able to delete a language
	Given the language which I have added should be displayed on my listings under Profile page
	When I click the X icon on my listings
	Then that language should be deleted from my listings

#negative testing text field for language
Scenario: Check possibility to make a blank on text field
	Given I clicked on the Langauge tab under profile page
	When I make a blank on the text field
	Then it should be not added and displayed alert message

Scenario: Check possibility to input maximum number of text
	Given I clicked on the Langauge tab under  Profile page
	When I entered 100 words on the text field
	Then it shoud be not added and displayed alert message

Scenario: Check possibility to input Korean language on the text field
	Given I clicked on the Langauge tab under  profile page
	When I enter Korean words on the field
	Then it should be not added and displayed alert message

Scenario: Check possibility to copy and paste on the text field
	Given I clicked on the Langauge tab under Profile Page
	When I copy words and paste on the text field
	Then it should be added

Scenario: Check Possibility to input uppercase and lowercase together on the text field
	Given I clicked on the Langauge tab under Profile Page
	When I enter uppercase and lowercase on the text field
	Then it should be added