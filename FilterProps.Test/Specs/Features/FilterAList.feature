Feature: Filter a list with empty filter

Scenario: Filter a list when there are no filters
	Given I have a list of 5 students
	And I have a collection of filters with no filters
	And I have a filter service
	When I ask the fiter service to filter the list
	Then I should get back a list of five students

