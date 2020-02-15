Feature: VendingMachineTest
	In order to get return on investment
	As a salesmen
	I want to test correct behavior of my vending machines


Scenario: Inserted money goes to money in transaction
	Given I have entered 50 cent into the vending machine
	And I have entered 20 cent into the vending machine
	Then Vending machine money in transaction should be 70 cent

Scenario: Return money empties money in transaction
	Given I have entered 50 cent into the vending machine
	And I push the return money button
	Then Vending machine money in transaction should be 0 cent

Scenario: Cannot insert more then one cent or coin at a time
	Given I have simultanuousely entered 20 cent and 50 cent into the vending machine
	Then An invalid operation exception should be thrown by the vending machine