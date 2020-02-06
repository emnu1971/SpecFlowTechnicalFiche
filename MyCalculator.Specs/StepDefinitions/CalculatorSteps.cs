using FluentAssertions;
using MyCalculator.Domain;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace MyCalculator.Specs.StepDefinitions
{
    [Binding]
    public class CalculatorSteps
    {

        private readonly Calculator calculator = new Calculator();

        #region Add of two numbers should calculate correct sum
        
        
        // Act
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            calculator.Add();
        }

        #endregion Add of two numbers should calculate correct sum

        #region Multiply of two numbers should calculate correct product

        // Act
        [When(@"I press multiply")]
        public void WhenIPressMultiply()
        {
            calculator.Multiply();
        }

        #endregion Multiply of two numbers should calculate correct product

        #region Common scenario steps

        // Arrange
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int operand)
        {
            calculator.Enter(operand);
        }

        // Assert
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedResult)
        {
            //Assert.Equal(expectedResult, calculator.Result);
            calculator.Result.Should().Be(expectedResult);
        }

        #endregion Common scenario steps
    }
}
