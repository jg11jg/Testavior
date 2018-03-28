﻿Feature: Get blogs
	In order to list blogs
	I want to be told a list of blogs

Background:
	Given A configured environment

Scenario: Specflow - Mvc - Get blogs should be ok
	Given the following blogs
	| Url             |
	| http://blog1.io |
	| http://blog2.io |
	| http://blog3.io |
	When I get the list of blogs from Web
	Then the result must be the following model
	| Url             |
	| http://blog1.io |
	| http://blog2.io |
	| http://blog3.io |