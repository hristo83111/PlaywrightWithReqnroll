@regression 
Feature: Login
	Testting the login feature of application

Background: 
	Given I navigate to the conduit.bondaracademy.com


@login
Scenario: Test login with multiple credentials
	When I enter "username" and "password"
	And I click the login button
	Then I should be logged in successfully
