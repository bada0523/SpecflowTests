Feature: User -> Showless the notification lists
Priority: Minor
As a User
I want the feature to showless the notification lists I have received
So that
I can read the notifications less than before

@mytag
#ShowLess notification
Scenario: Check if the user is able to select ShowLess the notifications
	Given I clicked notification dropdown bar
	When I click ShowLess button
	Then the notification lists should be displayed less than before
