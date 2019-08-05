Feature: Seller -> Add educations on my profile Details
Priority: Major
As a Seller
I want the feature to add educations Profile Details
So that
The people seeking for some educations can look into my details.

@mytag
#Add educations
Scenario Outline: Check if user could able to add educations
	Given I clicked on the Educations tab under profile page
	When I add new educations <education> and <degree>
	Then those educations <education> and <degree> should be displayed on my listings

	Examples:
		| education           | degree   |
		| Cornell             | Bachelor |
		| Industry Connect    | Diploma  |
		| Auckland University | Master   |

#edit education
Scenario: Check if user could able to edit a education
	Given I clicked the pencil icon on my listings under Profile page
	When I edit a language
	Then that updated education should be displayed on my listings

#delete education
Scenario: Check if user could able to delete a education
	Given the education which I have added should be displayed on my listings under Profile page
	When I click the X icon on my listings
	Then that education should be deleted from my listings

#Negative testing for text field for education
Scenario: Check possibility to make a blank on text field
	Given I clicked on the Educations tab under Profile page
	When I make a blank on the text field
	Then it should be not added and displayed alert message

Scenario: Check possibility to input maximum number of text
	Given I clicked on the Educations tab under profile Page
	When I entered 100 words on the text field
	Then it shoud be not added and displayed alert message

Scenario: Check possibility to input different language on the text field
	Given I clicked on the Educations tab under  profile page
	When I enter Korean words on the field
	Then it should be not added and displayed alert message

Scenario: Check possibility to copy and paste on the text field
	Given I clicked on the Educations tab under  profile Page
	When I copy words and paste on the text field
	Then it should be added

Scenario: Check Possibility to input uppercase and lowercase together on the text field
	Given I clicked on the Educations tab under Profile Page
	When I enter uppercase and lowercase on the text field
	Then it should be added