using FluentAssertions;
using MyCalculator.Domain;
using System;
using Xunit;

namespace MyCalculator.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator calculator = new Calculator();

        [Fact]
        public void Add_of_two_numbers_should_calculate_correct_sum()
        {
            // Arrange
            calculator.Enter(50);
            calculator.Enter(70);

            // Act
            calculator.Add();

            // Assert
            calculator.Result.Should().Be(120);

        }

        [Fact]
        public void Multiply_of_two_numbers_should_calculate_correct_product()
        {
            // Arrange
            calculator.Enter(6);
            calculator.Enter(5);

            // Act
            calculator.Multiply();

            // Assert
            calculator.Result.Should().Be(30);

        }
    }
}
