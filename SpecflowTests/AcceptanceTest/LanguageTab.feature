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
	Given The language should be visible on language list which I want to edit under Profile page
	When I edit a language
	Then that updated language should be displayed on my listings

#deleting language
Scenario: Check if user could able to delete a language
	Given the language have added should be displayed on my listings
	When I click the X icon on my language listings
	Then that language should be deleted from my listings
