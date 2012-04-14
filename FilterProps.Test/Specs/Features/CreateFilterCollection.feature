Feature: Create Filter Collection
	In order to be able to collect filters
	As a user
	I want to create a collection of filters of particular type

Scenario: Create an empty collection
	Given I have a student class
	When I create new filter collection of type Student
	Then I should get an empty collection of filters
	And The collection expression should be null

