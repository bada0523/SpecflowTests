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
		| Automation Testing |
		| JIRA     |
		| Cucumber |

#Edit skill
Scenario: Check if user could able to edit a skill
	Given The skill have added should be displayed on skill list
	When I edit a skill
	Then that updated skill should be displayed on my listings

#delete skill
Scenario: Check if user could able to delete a skill
	Given the skill which I have added should be displayed on skill listings
	When I click the X icon on skill listings
	Then that skill should be deleted from my listings