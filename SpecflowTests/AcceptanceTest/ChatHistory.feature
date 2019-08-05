Feature: User -> Check check history
Priority: Major
As a User
I want the feature to Check check history
So that
I can read my chat history

@mytag
#Read chat history
Scenario: Check if the user is able to check my chat history
	Given I clicked chat button
	When I select chat history what I want to open
	Then the chat history should be displayed
