Feature: Maintenance
	In order to avoid Goldorak gets a mental break down
	As a monteur
	I want to be able to maintain Goldorak correctly


Scenario Outline: Change Oil
	Given I'm in maintenance for <secs> seconds
	Examples: 
	| secs |
	| 1    |
	| 1    |
	| 1    |

Scenario Outline: Charge Batteries
	Given I'm in maintenance for <secs> seconds
	Examples: 
	| secs |
	| 1    |
	| 1    |
	| 1    |

Scenario Outline: Remove and Replace Filters
	Given I'm in maintenance for <secs> seconds
	Examples: 
	| secs |
	| 1    |
	| 1    |
	| 1    |	

Scenario Outline: Calibrate Ignition
	Given I'm in maintenance for <secs> seconds
	Examples: 
	| secs |
	| 1    |
	| 1    |
	| 1    |
	
Scenario Outline: Check Remote Control
	Given I'm in maintenance for <secs> seconds
	Examples: 
	| secs |
	| 1    |
	| 1    |
	| 1    |