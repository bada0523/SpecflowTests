Feature: User -> Delete the notifications
Priority: Minor
As a User
I want the feature to delete the notification
So that
I can delete the notifications

@mytag
#Delete notification
Scenario: Check if the user is able to delete the notification
	Given I clicked notification dropdown bar
	When I click a notification
	And I click delete button
	Then the notification should be deleted
