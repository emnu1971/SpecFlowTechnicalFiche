Feature: Goldorak
	In order to play the Goldorak game
	As a human player
	I want my goldorak attributes to be correctly created


Scenario: Taking no damage when hit doesn't affect health
	Given I'm a new Goldorak
	When I take 0 damage
	Then My health should remain 100

Scenario: Starting health is reduced when hit
	Given I'm a new Goldorak
	When I take 40 damage
	Then My health should remain 60

Scenario: Taking too much damage results in Goldoraks death
	Given I'm a new Goldorak
	When I take 100 damage
	Then My health should remain 0

#Scenario: Taken damage depends on damage resistance and position of impact
#	Given I'm a new Goldorak
#	And I have a default damage resistance of 20
#	And The position of impact is my Head
#	When I take 40 damage
#	Then My health should remain 90
	
Scenario Outline: Taken damage depends on damage resistance and position of impact (outline)
	Given I'm a new Goldorak
	And I have a default damage resistance of <defaultDamageResistance>
	And The position of impact is <positionOfImpact>
	When I take <damageTaken> damage
	Then My health should remain <expectedHealth>

	Examples:
	| defaultDamageResistance | positionOfImpact | damageTaken | expectedHealth |
	| 0                       | Other            | 10          | 90             |
	| 20                      | Head             | 40          | 90             |

Scenario: Head PositionOfImpact gets default 10 damage resistance when hit
	Given I'm a new Goldorak
	And I have a default damage resistance of 10
	And The position of impact is Head
	When I take 40 damage
	Then My health should remain 80

Scenario: Head PositionOfImpact gets default 10 damage resistance when hit data table
	Given I'm a new Goldorak
	And I have the following attributes
	| attribute        | value |
	| PositionOfImpact | Head  |
	| Resistance       | 10    |
    When I take 40 damage
	Then My health should remain 80


Scenario: UfoState Docked restores all health
	Given I'm a new Goldorak
	Given My Goldorak character ufo state is Docked
	When I take 40 damage
	And  Execute a repair health request
	Then My health should remain 100

#multi column step table-data
Scenario: Total magical power
	Given I'm a new Goldorak
	Given I have the following magical items
	| name          | value | power |
	| FulguroPoint  | 5     | 100   |
	| AsteroHache   | 10    | 125   |
	| RetroLaser    | 15    | 150   |
	| Pulvonium     | 20    | 175   |
	| CornoFulgure  | 25    | 200   |
	| PlaniTron     | 30    | 225   |
	| ClavicoGyre   | 35    | 250   |
	| MegaVolts     | 40    | 275   |
	| MissilesGamma | 45    | 300   |
	Then My total magical power should be 1800

#custom data conversion
Scenario: Requesting a restore health when not maintained properly has no effect
	Given I'm a new Goldorak
	Given I last had maintenance 3 days ago
	When I take 40 damage
	And I request as restore health
	Then My health should remain 60

#automatic applying custom transformations
Scenario: Teammates are worth value
	Given I'm a new Goldorak
	Given I have the following team mates
	| name      | value |
	| ovterre   | 10    |
	| venusiac  | 20    |
	| phosoirac | 30    |
	| aquarak   | 40    |
	Then my team mates should be worth 100

#using context injection
@docked @ignore
Scenario: Goldorak does not lose magical power when docked
	Given I'm a new Goldorak
	And I'm Docked to my base station
	And I have a magical item MegaVolts with a power of 275
	When I use a magical item MegaVolts
	Then The magical item MegaVolts power should not be reduced

