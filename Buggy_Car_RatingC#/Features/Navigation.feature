Feature: Navigation

As a user I want to navigate through all pages on the site

Scenario: Logged user can access navigate to all site pages
	Given a user is on Website Landing Page and logged in
	Then the user navigate to Popular Model then confirm model page and back to main page successfully
	Then the user navigate to Overall Rating then confirm overall page and back to main page succesfully

Scenario: Non Logged user can access navigate to all site pages
	Given a user is on Website Landing Page 
	Then the user navigate to Popular Model then confirm model page and back to main page successfully
	Then the user navigate to Overall Rating then confirm overall page and back to main page succesfully
