Feature: MoneyTest
	In order to earn money
	As a vending machine salesmen
	I want to be sure moy money object acts correctly


Scenario: Sum of wo moneys produces correct result
	Given I have entered 50 eurocent into the money object
	And I have entered 20 eurocent into the money object
	When I sum them
	Then the result should be 70 eurocent on the screen

Scenario: Two money instances are equal if they contain the same money amount
	Given I have 4 twenty cents and 2 ten cents
	And my friend has 1 ten cent and 2 twenty cents and 1 fifty cent
	Then we both have the same amount of money which is 2.00 euro in total

Scenario: Money with negative value makes no sense in our vending machine
	Given I have the following money items
	| name       | value |
	| fivecent   | -1    |
	| tencent    | -1    |
	| twentycent | -1    |
	| fiftycent  | -1    |
	| oneeuro    | -1    |
	| twoeuro    | -1    |
	Then 6 invalid operation exception should be returned