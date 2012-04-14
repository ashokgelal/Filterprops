Feature: Clear filter collection

Scenario: Clear filters
	Given I have a collection of filters
	When I clear the collection
	Then The filters count should be 0
	And The collection expression should be null
