@regression @ui
Feature: Login
	Testting the login feature of application

Background: 
	Given I navigate to the saucedemo.com


@login
Scenario: Test login with valid credentials
    When I login with credentials:
      | username      | password     |
      | standard_user | secret_sauce |
    Then I should be logged in successfully
