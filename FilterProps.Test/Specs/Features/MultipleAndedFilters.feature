Feature: Adding multiple filters which are ANDed together

Background: 
	Filters can be ANDed together which will return just the objects that satisfy all the conditions.

	Given These students:
		| FirstName      | LastName    | Gender | IsInternational |
		| Jesse          | Fredericks  | Male   | false           |
		| Elenor         | Ruel        | Female | true            |
		| Hàn Ngọc       | Trai        | Female | true            |
		| Catherine      | Jackson     | Female | false           |
		| Mahjub Khalid  | Khalid      | Male   | true            |
		| Ashwàq Jawahir | Shalhoub    | Male   | false           |
		| Douglas        | Rego        | Male   | false           |
		| Jose           | Kitterman   | Female | false           |
		| Nancy          | Jackson     | Female | false           |
		| Jose           | Roberts     | Male   | false           |
		| Bob            | Jackson     | Male   | false           |
		| Bobby          | Rackson     | Female | false           |
		| Boba           | Bob Jackson | Female | true            |
	And I add a filter where LastName contains Jackson
	And I AND a filter where Gender is Female

Scenario: Multiple filters with Lastname AND Gender

	When I apply the filters
	Then These students should be on the list

		| FirstName | LastName    | Gender | IsInternational |
		| Catherine | Jackson     | Female | false           |
		| Nancy     | Jackson     | Female | false           |
		| Boba      | Bob Jackson | Female | true            |


Scenario: Multiple filters with Lastname AND Gender AND IsInternational

	And I add a filter where IsInternataional is true
	When I apply the filters
	Then These students should be on the list

		| FirstName | LastName    | Gender | IsInternational |
		| Boba      | Bob Jackson | Female | true            |