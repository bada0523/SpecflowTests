Feature: Seller -> Add skills on my profile Details
Priority: Major
As a Seller
I want the feature to add skills Profile Details
So that
The people seeking for some skills can look into my details.

@mytag
#Add Skills
Scenario Outline: Check if user could able to add skills
	Given I clicked on the Skills tab under profile page
	When I add new skills <skill>
	Then those skills <skill> should be displayed on my listings

	Examples:
		| skill    |
		| Selenium |
		| JIRA     |
		| Cucumber |

#Edit skill
Scenario: Check if user could able to edit a skill
	Given I clicked the pencil icon on my listings under Profile page
	When I edit a language
	Then that updated skill should be displayed on my listings

#delete skill
Scenario: Check if user could able to delete a skill
	Given the skill which I have added should be displayed on my listings under Profile page
	When I click the X icon on my listings
	Then that skill should be deleted from my listings

#Negative testing for text field skill
Scenario: Check possibility to make a blank on text field
	Given I clicked on the Skills tab under profile Page
	When I make a blank on the text field
	Then it should be not added and displayed alert message

Scenario: Check possibility to input maximum number of text
	Given I clicked on the Skills tab under Profile Page
	When I entered 100 words on the text field
	Then it shoud be not added and displayed alert message

Scenario: Check possibility to input different language on the text field
	Given I clicked on the Skills tab under  profile page
	When I enter Korean words on the field
	Then it should be not added and displayed alert message

Scenario: Check possibility to copy and paste on the text field
	Given I clicked on the Skills tab under  Profile page
	When I copy words and paste on the text field
	Then it should be added

Scenario: Check Possibility to input uppercase and lowercase together on the text field
	Given I clicked on the Skills tab under  profile Page
	When I enter uppercase and lowercase on the text field
	Then it should be added