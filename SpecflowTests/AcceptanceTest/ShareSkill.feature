Feature: Seller -> Add share skill for skill trade
Priority: Major
As a Seller
I want the Info to add share skill for skill trade
So that
The people seeking for some shared skills Info can look into my details.

@mytag
#Adding a shared skill
Scenario: Check if user could able to add a Shared Skill on my listings
	Given I clicked on the button Share Skill under Profile page
	When I add a new shared skill
	Then the lists of shared skill you have been posting should be displayed on my listings

#Editing a shared skill
Scenario: Check if user could able to edit a Shared Skill on my listings
	Given I clicked on the Manage Listings tab under Profile page
	When I clicked the pencil icon on my listings
	And I edit a shared skill
	Then that updated shared skill should be displayed  on my listings

#Deleting a shared skill
Scenario: Check if user could able to delete a Shared Skill on my listings
	Given I clicked on the Manage listings tab under Profile page
	When I delete a shared skill
	Then that shared skill should be deleted from my listings

#Check active and deactive mod on listings manage tab
Scenario: Check response when shared skill Info is turned deactivated
	Given A shared skill Info which is I created should be displayed on Manage Listings under ListingManagement page
	When I clicked the button Active to deactive
	Then it should be not searchable by the others
