Feature: Calculator
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@CalculationTest
Scenario Outline: Calculation between two whole numbers via API
	Given I enter leftNumber, operator and rightNumber on the calculator
	| LeftNumber   | Operator   | RightNumber   |
	| <LeftNumber> | <Operator> | <RightNumber> |
	When I press Calculate
	Then I should see result <Result> returned
	Examples: 
	| LeftNumber | Operator | RightNumber | Result    |
	| 0          | -        | 0           | 0         |
	| 0          | -        | 1           | -1        |
	| 0          | -        | 999         | -999      |
	| 9999       | -        | 999         | 9000      |
	| 0          | +        | 0           | 0         |
	| 1          | +        | 9           | 10        |
	| 99         | +        | 1           | 100       |
	| 1          | +        | 999         | 1000      |
	| 999        | +        | 999         | 1998      |
	| 0          | *        | 0           | 0         |
	| 0          | *        | 999         | 0         |
	| 999        | *        | 999         | 998001    |
	| 1          | /        | 1           | 1         |
	| 0          | /        | 0           | Undefined |
	| 0          | /        | 1           | 0         |
	| 1          | /        | 0           | Undefined |