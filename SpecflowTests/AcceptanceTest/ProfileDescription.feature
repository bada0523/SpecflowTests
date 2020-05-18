Feature: Seller -> Add description on my profile Details
Priority: Major
As a Seller
I want the feature to add description Profile Details
So that
The people seeking for some description can look into my details.
	

@mytag
#Writing my description
Scenario: Check if user could able to write a description
	Given I clicked the pencil icon next to description under profile page
	When I write about my information
	Then that information should be displayed on description section
