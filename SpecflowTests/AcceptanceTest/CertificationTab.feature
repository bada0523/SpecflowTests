Feature: Seller -> Add certifications on my profile Details
Priority: Major
As a Seller
I want the feature to add certifications Profile Details
So that
The people seeking for some certifications can look into my details.

@mytag
#Add Certifications
Scenario Outline: Check if user could able to add certifications
	Given I clicked on the Certifications tab under profile page
	When I add new certification <certification> and <from>
	Then those certifications <certification> and <from> should be displayed on my listings

	Examples:
		| certification                              | from  |
		| Foundation Certificate in Software Testing | ISTQB |
		| Network Certificate                        | Cisco |
		| Security Certificate in Software Testing   | NZQA  |

#Edit certification
Scenario: Check if user could able to edit a certification
	Given I clicked the pencil icon on my listings under Profile page
	When I edit a language
	Then that updated certification should be displayed on my listings

#delete certification
Scenario: Check if user could able to delete a certification
	Given the certification which I have added should be displayed on my listings under Profile page
	When I click the X icon on my listings
	Then that certification should be deleted from my listings

#Negative testing for text field for certification
Scenario: Check possibility to make a blank on text field
	Given I clicked on the Certifications tab under Profile page
	When I make a blank on the text field
	Then it should be not added and displayed alert message

Scenario: Check possibility to input maximum number of text
	Given I clicked on the Certifications tab under profile Page
	When I entered 100 words on the text field
	Then it shoud be not added and displayed alert message

Scenario: Check possibility to input different language on the text field
	Given I clicked on the Certifications tab under  Profile page
	When I enter Korean words on the field
	Then it should be not added and displayed alert message

Scenario: Check possibility to copy and paste on the text field
	Given I clicked on the Certifications tab under  profile age
	When I copy words and paste on the text field
	Then it should be added

Scenario: Check Possibility to input uppercase and lowercase together on the text field
	Given I clicked on the Certifications tab under  profile Page
	When I enter uppercase and lowercase on the text field
	Then it should be added