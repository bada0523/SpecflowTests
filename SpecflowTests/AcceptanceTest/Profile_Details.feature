Feature: Seller -> Set Availability, Hours and Earn Target on my profile Details
Priority: Major
As a Seller
I want the feature to Set Availability, Hours and Earn Target on Profile Details
So that
The people seeking for some information can look into my details.

@mytag
#Set Availability
Scenario: Check if user could able to set availability
	Given I have clicked Availability edit icons
	When I select Availability as Full Time
	Then Availability should be set as Full Time

#Set Hours
Scenario: Check if user could able to set Hours
	Given I have clicked Hours edit icons
	When I select Hours as As Needed
	Then Hours should be set as As Needed

#Set Earn Target
Scenario: Check if user could able to set Earn Target
	Given I have clicked Earn Target edit icons
	When I select Earn Target as More than 1000 per month
	Then Earn Target should be set as More than 1000 per month
