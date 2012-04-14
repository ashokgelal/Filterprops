Feature: Filter a list based on some properties

Background: 
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

Scenario Outline: Filter students that satisfies firstname
	And I add a filter where FirstName is <FirstName>
	When I apply the filters
	Then The student list should contain <FirstName>

	Examples: Should showup on the list

		| FirstName | LastName   | Gender | IsInternational |
		| Jesse     | Fredericks | Male   | false           |
		| Elenor    | Ruel       | Female | true            |


Scenario: Filter students that share common firstname

	And I add a filter where FirstName is Jose
	When I apply the filters
	Then These students should be on the list

		| FirstName | LastName  | Gender | IsInternational |
		| Jose      | Kitterman | Female | false           |
		| Jose      | Roberts   | Male   | false           |

Scenario: Filter students that share common lastname

	And I add a filter where LastName is Jackson
	When I apply the filters
	Then These students should be on the list

		| FirstName | LastName    | Gender | IsInternational |
		| Catherine | Jackson     | Female | false           |
		| Nancy     | Jackson     | Female | false           |
		| Bob       | Jackson     | Male   | false           |

Scenario: Filter students that contains common lastname

	And I add a filter where LastName contains Jackson
	When I apply the filters
	Then These students should be on the list

		| FirstName | LastName    | Gender | IsInternational |
		| Catherine | Jackson     | Female | false           |
		| Nancy     | Jackson     | Female | false           |
		| Bob       | Jackson     | Male   | false           |
		| Boba      | Bob Jackson | Female | true            |

Scenario: Filter students who are international

	And I add a filter for international students
	When I apply the filters
	Then These students should be on the list

		| FirstName     | LastName    | Gender | IsInternational |
		| Elenor        | Ruel        | Female | true            |
		| Hàn Ngọc      | Trai        | Female | true            |
		| Mahjub Khalid | Khalid      | Male   | true            |
		| Boba          | Bob Jackson | Female | true            |
