Feature: User -> Mark as read the notification
Priority: Minor
As a User
I want the feature to mark as read the notification
So that
I can mark as read the notification what I have chosen

@mytag
#Mark as read notification
Scenario: Check if the user is able to mark as read the notification
	Given I clicked Dashboard Tab under Profile page
	When I mark as read the notification
	Then the notification should be marked as read
