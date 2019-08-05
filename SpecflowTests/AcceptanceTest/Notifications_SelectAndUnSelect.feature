Feature: User -> Select or UnSelect the notifications
Priority: Minor
As a User
I want the feature to select or unselect the notifications
So that
I can select or unselect the notifications

@mytag
#Select notification
Scenario: Check if the user is able to select the notification
	Given I clicked Dashboard Tab under Profile page
	When I select notification what I want
	Then the notification what I have chosen should be selected

#Unselect notification
Scenario: Check if the user is able to unselect the notification
	Given I clicked Dashboard Tab under Profile page
	When I unselect notification what I want
	Then the notification what I have chosen should be unselected
