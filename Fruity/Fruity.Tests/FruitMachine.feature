Feature: FruitMachine	
	As a gambling machine owner
	I want the machine to spin only when there are credits inserted
	So that I don't go out of business

@mytag
Scenario: Spin on it
	Given there are 10 credits in the machine	
	When I spin the reels
	Then there should be 9 credits in the machine

Scenario: Don't spin on it
	Given there are 0 credits in the machine	
	When I spin the reels
	Then there should be 0 credits in the machine

Scenario: Disable spin
	Given there are 0 credits in the machine	
	Then I should not be able to play

Scenario: Insert coin
	Given there are 0 credits in the machine	
	When I insert a coin
	Then I should be able to play
	And there should be 1 credits in the machine