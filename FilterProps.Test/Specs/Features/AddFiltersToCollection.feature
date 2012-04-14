Feature: Add filters to a filter collection

Background: 
	Given I have a filter collection of type Student
	When I add a new filter

Scenario: Add a new filter to a collection
	Then The filter should be added to the collection
	And The filter collection count should be 1
	And The filter expression should not be null

Scenario: Add multiple filters to a collection
	And I add a list of two filters
	Then The filter collection count should be 3