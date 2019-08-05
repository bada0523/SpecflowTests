Feature: Seller -> Check received requests from the other users
Priority: Major
As a Seller
I want the feature to check received requests from the other users
So that
I can receive requests and check it

@mytag
#Check received request
Scenario: Check if the user is able to receive the request
	Given I clicked Received Requests under manage requests Tab
	When I click a request post I have received
	Then the request should be displayed
