Feature: Profile

As a User I want to update My Profile


Scenario: Profile Update
	Given a user is on Profile page
	When the user updates profile form 
	Then the user should see success Message
	Then the user should see profile data has changed
