Feature: User -> MoreRead the notification lists
Priority: Minor
As a User
I want the feature to MoreRead the notification lists I have received
So that
I can read the notifications more than before

@mytag
#ReadMore notification
Scenario: Check if the user is able to select MoreRead the notifications
	Given I clicked notification dropdown bar
	When I click MoreRead button
	Then the notification lists should be displayed more than before
