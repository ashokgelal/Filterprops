Feature: Adding multiple filters which are ORed together

Background: 
	Filters can be ORed together which will return just the objects that one of the conditions.

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
	And I OR a filter where Gender is Female

Scenario: Multiple filters with Lastname OR Gender

	When I apply the filters
	Then These students should be on the list

		| FirstName | LastName    | Gender | IsInternational |
		| Elenor    | Ruel        | Female | true            |
		| Hàn Ngọc  | Trai        | Female | true            |
		| Catherine | Jackson     | Female | false           |
		| Jose      | Kitterman   | Female | false           |
		| Nancy     | Jackson     | Female | false           |
		| Bob       | Jackson     | Male   | false           |
		| Bobby     | Rackson     | Female | false           |
		| Boba      | Bob Jackson | Female | true            |

Scenario: Multiple filters with Lastname OR Gender OR FirstName is Ashwàq

	And I OR a filter where FirstName is Ashwàq
	When I apply the filters
	Then These students should be on the list

		| FirstName      | LastName    | Gender | IsInternational |
		| Elenor         | Ruel        | Female | true            |
		| Hàn Ngọc       | Trai        | Female | true            |
		| Catherine      | Jackson     | Female | false           |
		| Ashwàq Jawahir | Shalhoub    | Male   | false           |
		| Jose           | Kitterman   | Female | false           |
		| Nancy          | Jackson     | Female | false           |
		| Bob            | Jackson     | Male   | false           |
		| Bobby          | Rackson     | Female | false           |
		| Boba           | Bob Jackson | Female | true            |

