﻿Feature: People -> Seeking for some shared skills Info
Priority: Major
As a Skill trader
I want to skill swap with seller
So that
It is available to see and contact with seller for skill swap

@mytag
#The ways of that people could able to look into my details
Scenario: Check if people could able to look into my details by searching skillname
	Given people type skill name on the search bar for 'Test Analyst'
	When people click my Info on a result of user's search
	Then the details of my shared skill should be displayed

Scenario: Check if people could able to look into my details by exploring categories
	Given the categories should be displayed on the homepage
	When people click Programming & Tech on the category
	And people click QA under the category of Programming & Tech
	And people click my info on a result of user's search
	Then the details of my shared skilll should be displayed

Scenario: Check if people could able to look into my details by searching username
	Given the categories should be displayed on the Homepage
	When people fill username on username search bar for "harris jung"
	Then the details of my shared skill should be displayed

#The ways of that people could able to contact with seller
Scenario: Check if people could able to contact with seller by chat
	Given people should able to read seller's  Info
	When people click the button chat
	Then the chat room should be opened to seller and people both of them

Scenario: Check if people could able to leave a message to seller
	Given people should able to read seller's Info
	When people leave a message to the seller
	Then that message should be sent to the seller and then, seller should able to read user's message

#Negative testing for search
Scenario Outline:  Check response when I make a spacing of the keyword
	Given people input <keyword> on the search bar
	When I search the keywords<keyword>
	Then the both of results should be displayed with seller's details

	Examples:
		| keyword      |
		| Test Analyst |
		| TestAnalyst  |