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

#Negative for chat
Scenario: Check possibility to copy and paste in chat room
	Given I opened chat room
	When I copy and paste a thing in chat room
	Then this should be worked

Scenario: Check possibility to do not enter any words and just send message in chat room
	Given I opened chat room
	When I do not enter any words and just send it
	Then it should be not sent the message

Scenario: Check possibility to input maximum number of area
	Given I opened chat room
	When I entered 1000 words in chat room
	Then it shoud be not sent

Scenario: Check possibility to input different language in chat room
	Given I opened chat room
	When I enter Korean words in chat room
	Then it should be entered Korean words

Scenario: Check possibility to input uppercase and lowercase together in chat room
	Given I opened chat room
	When I enter uppercase and lowercase in chat room
	Then it should be added uppercase and lowercase

Scenario: Check possibility to input special characters in chat room
	Given I opened chat room
	When I enter special characters in chat room
	Then it should be added special characters