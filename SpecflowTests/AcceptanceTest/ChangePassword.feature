Feature: Seller -> Change to new password what I want
Priority: Minor
As a Seller
I want the feature to Change the password
So that
Seller can change the password what I want

Background:
	Given I clicked Hi username dropdown

@mytag
#Change password
Scenario: Check if the user is able to change the password
	And I clicked change password button
	When I enter new password, current password and confirm password correctly
	Then the password should be changed as new password I have entered