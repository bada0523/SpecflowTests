Feature: SetAvailability_Hours_EarnTarget
	Priority: Major
As a Seller
I want the feature to add Profile Details such as location, availability, Hours and Earn Target
So that
Seller can set Profile Details such as availability, Hours and Earn Target under profile page

@mytag
#Set Location
Scenario: Check if user could able to set details of Location under profile page
	Given I clicked pencil icon next to location
	When I set country to South Korea
	And I set a city to Seoul
	Then It should be set my location as I have chosen

#Set Availability
Scenario: Check if user could able to set details of Availability under profile page
	Given I clicked the pencil icon next to Availability
	When i set Avaiability to Full time
	Then this Info should be set as I have chosen

#Set Hours
Scenario: Check if user could able to set details of Hours under profile page
	Given I clicked the pencil icon next to Hours
	When I set Hours to As needed
	Then the Hours should be set as I have chosen

#set Earn Target
Scenario: Check if user could able to set details of Earn Target under profile page
	Given I clicked the pencil icon next to Earn Target
	When I set Hours to More than $1000 per month
	Then the Earn Target should be set as I have chosen