Feature: User -> Sign up new account
Priority: Major
As a User
I want the feature to sign up new account for SkillSwap website
So that
I can use the features of website to share some skills with the other users

@mytag
Scenario: Check if the user is able to sign up
	Given I clicked join button
	When I enter a credential
	Then that account should be registered