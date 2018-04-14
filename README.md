# ResistorCalculatorNet45

Inspired by https://github.com/raajnadar/resistor-color-calculator (Not a C# code)

Project uses restful API to POST ColorBandValues in a JSON object to the controller "ResistorCalController.cs" and the controller uses an object instance of OhmValueCalculator to calculate and returns a string that contains "resistance" and "tolerance" respectively for the Resistor. OhmValueCalculator.cs and IOhmValueCalculator are under the folder "Business". 

Open MVCTest solution, ResistorCalculatorTest is the main project and ResistorCalculatorUnitTest project contains the unit test for testing the business logic. 

-Hesam
