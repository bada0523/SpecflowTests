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
	Given The certificate have added on certificate listings
	When I edit a certificate
	Then that updated certification should be displayed on my listings

#delete certification
Scenario: Check if user could able to delete a certification
	Given the certification have added should be displayed on certificate listings
	When I click the X icon on my listings
	Then that certification should be deleted from my listings