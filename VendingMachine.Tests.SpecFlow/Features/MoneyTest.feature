Feature: MoneyTest
	In order to earn money
	As a vending machine salesmen
	I want to be sure moy money object acts correctly


Scenario: Sum of wo moneys produces correct result
	Given I have entered 50 eurocent into the money object
	And I have entered 20 eurocent into the money object
	When I sum them
	Then the result should be 70 eurocent on the screen
