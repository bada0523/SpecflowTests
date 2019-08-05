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

#Negative for Change Password
Scenario: Check possibility to make a blank on text field
	When I make a blank on the text field
	Then it should be not worked and displayed alert message that Please fill all the details before Submit

Scenario: Check possibility to input maximum number of text field
	When I entered 1000 words on the text field
	Then it should be not worked and displayed alert message that Please fill in range of maximum number

Scenario: Check possibility to input not matched current password on the text field
	When I enter not matched password on the current password field
	Then it should be not added and displayed alert message that Passwords does not match

Scenario: Check possibility to copy and paste on the text field
	When I copy words and paste on the text field
	Then it should be worked

Scenario: Check possibility to input uppercase and lowercase together on the text field
	When I enter uppercase and lowercase on the text field
	Then it should be worked and distinguishable between uppercase and lowercase

Scenario: Check possibility to input number on the text field
	When I enter number on the text field
	Then it should be entered correctly

Scenario: Check possibility to input special characters on thext field
	When I enter special characters on text field
	Then it should be worked correctly

Scenario: Check possibility to input same passwords current password and new password
	When I enter same passwords on current password and new password fields
	Then it should be rejected and displayed alert message that You cannot use same password