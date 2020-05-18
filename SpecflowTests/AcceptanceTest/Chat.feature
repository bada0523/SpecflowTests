Feature: User -> chat with the other users
Priority: Major
As a User
I want the feature to chat with the otuher users
So that
I can have conversation with the other users

@mytag
#open chat
Scenario: Check if the user is able to chat with the users
	Given I opened the other people's shared skill details page
	When I click chat button
	Then chat room should be made and start to talk