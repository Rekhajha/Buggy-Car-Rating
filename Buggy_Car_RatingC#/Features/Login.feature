Feature: Login
	As a user I want to be able to log in and log out


Scenario: Log in with valid credentials
	Given a user is on Website Landing Page
	When the user logs in to the application with valid Credentials
	Then the user should be succesfully logged in

Scenario: Log in with invalid credentials
	Given a user is on Website Landing Page	
	When the user logs in to the application with invalid credential
	Then the user should be not be able to login successfully

Scenario: Log off
	Given a user logged in
	When the user click the log out link
	Then the user should be log out
