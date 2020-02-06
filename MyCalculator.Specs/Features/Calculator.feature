Feature: Calculator
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mycalculator
Scenario: Add of two numbers should calculate correct sum
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

Scenario: Multiply of two numbers should calculate correct product
	Given I have entered 5 into the calculator
	And I have entered 6 into the calculator
	When I press multiply
	Then the result should be 30 on the screen