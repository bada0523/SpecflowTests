Feature: Seller -> Check the requests which I have sent
Priority: Major
As a Seller
I want the feature to check the requests which I have sent to the other users
So that
I can check sent requests

@mytag
#Check sent requests
Scenario: Check if the user is able to Check the Sent request
	Given I clicked Sent Requests under manage requests Tab
	When I click a request post I have sent
	Then this request should be displayed
