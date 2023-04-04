Feature: Voting
As a User I can use voting functionality. I can vote and comment on the site.

Scenario: Logged in user can vote
	Given a user is log in and navigate to most popular page
	When the user made a comment  
	And click on vote button 
	Then vote should count and comment textbox should not visible

Scenario: Not Logged in user can't vote
	Given a user navigate to most popular page without log in
	Then the user should see message to login in for vote