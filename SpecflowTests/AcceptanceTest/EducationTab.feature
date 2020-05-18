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
		| MVP Studio          | Bachelor |
		| Industry Connect    | Diploma  |
		| Auckland University | Master   |

#edit education
Scenario: Check if user could able to edit a education
	Given The education have added should be displayed on education listings
	When I edit a education
	Then that updated education should be displayed on my listings

#delete education
Scenario: Check if user could able to delete a education
	Given the education have added should be displayed on education listings
	When I click the X icon on education listings
	Then that education should be deleted from my listings