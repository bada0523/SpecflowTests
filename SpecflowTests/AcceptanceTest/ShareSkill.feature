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
	When I clicked the X icon on my listings
	And I clicked the button Yes on Alert page
	Then that shared skill should be deleted from my listings

#Check active and deactive mod on listings manage tab
Scenario: Check response when shared skill Info is turned deactivated
	Given A shared skill Info which is I created should be displayed on Manage Listings under ListingManagement page
	When I clicked the button Active to deactive
	Then it should be not searchable by the others

#Negative testing for text field share skill application
Scenario: Check possibility to make a blank on text field
	Given I clicked on the button Share Skill under  Profile page
	When I make a blank on the text field
	Then it should be not added and displayed alert message

Scenario: Check possibility to input maximum number of text
	Given I clicked on the button Share Skill under  profile page
	When I entered 100 words on the text field
	Then it shoud be not added and displayed alert message

Scenario: Check possibility to input different language on the text field
	Given I clicked on the button Share Skill under  Profile Page
	When I enter Korean words on the field
	Then it should be not added and displayed alert message

Scenario: Check possibility to copy and paste on the text field
	Given I clicked on the button Share Skill under  profile Page
	When I copy words and paste on the text field
	Then it should be added

Scenario: Check Possibility to input uppercase and lowercase together on the text field
	Given I clicked on the button Share Skill under profile page
	When I enter uppercase and lowercase on the text field
	Then it should be added

#Negative testing for Time Picker & Date Picker
Scenario: Check response when sets the Start date or End date in the past
	Given I clicked on the button Share Skill under Profile Page
	When I set past date for Start date or End date
	Then it should be stopped with alert message to warn that it cannot be set to a day in the past

Scenario: Check possibility to input the words on Start date and End date
	Given I clicked on the button share Skill under Profile page
	When I enter the words on Start date and End date
	Then it should be not allowed to write

Scenario: Check possibility to copy and paste on Start date and End date
	Given I clicked on the button Share skill under Profile page
	When I copy words and paste on Start date and End date
	Then it should be not worked

#Upload files
Scenario: Check response when file is uploaded which the types are not supported
	Given I clicked on the button share skill under Profile page
	When I upload the file which the types are not supported
	Then it should be stopped with alert message that only supported file types are gif / jpeg / png / jpg / doc(x) / pdf / txt / xls(x)

Scenario: Check possibility to upload maximum number of file
	Given I clicked on the button Share Skill under profile page
	When I upload over 5 files
	Then it should be not allowed to upload more than 5 files

Scenario: Check response when over 2mb size of file is uploaded
	Given I clicked on the button Share skill under Profile Page
	When I upload the file which size is over 2mb
	Then it should be stopped with alert message that Max file size is 2 MB

Scenario: Check possibility to upload the same files
	Given I clicked on the button Share skill under profile page
	When I upload the same files
	Then it should be not allowed to upload the same one as I have uploaded