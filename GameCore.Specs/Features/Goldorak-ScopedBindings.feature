Feature: Goldorak-Scoped-Bindings
	In order to play the Goldorak game
	As a human player
	I want my goldorak attributes to be correctly created

@undocked
Scenario: Starting health is reduced when hit undocked
	Given I'm a new Goldorak
	When I take 40 damage
	Then My health should remain 60


@docked
Scenario: Starting health is repaired when hit docked
	Given I'm a new Goldorak
	When I take 40 damage
	Then My health should remain 100

