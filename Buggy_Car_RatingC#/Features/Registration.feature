Feature: Registration

As a User I want to register on buggy car rating website.

Scenario: Register
	Given a user is on Register Page 
	When a user enter all details on Registration form
	Then verify registration is a success
	Then use should log in successfully
