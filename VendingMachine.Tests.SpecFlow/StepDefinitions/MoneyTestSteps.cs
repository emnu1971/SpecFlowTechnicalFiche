using FluentAssertions;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using VendingMachine.Domain;

namespace VendingMachine.Tests.SpecFlow.StepDefinitions
{
    [Binding]
    public class MoneyTestSteps

    {
        private readonly Stack<Money> moneys = new Stack<Money>();

        
        // Arrange
        [Given(@"I have entered (.*) eurocent into the money object")]
        public void GivenIHaveEnteredEurocentIntoTheMoneyObject(int p0)
        {
            
            // push money amount on the stack
            switch (p0)
            {
                case 5:
                    // 5eurocent
                    moneys.Push(Money.FiveEuroCent);
                    break;
                case 10:
                    // 10eurocent
                    moneys.Push(Money.TenEuroCent);
                    break;
                case 20:
                    // 20eurocent
                    moneys.Push(Money.TwentyEuroCent);
                    break;
                case 50:
                    // 50eurocent
                    moneys.Push(Money.FiftyEuroCent);
                    break;
                case 1:
                    // 1eurocoin
                    moneys.Push(Money.OneEuroCoin);
                    break;
                case 2:
                    // 2eurocoin
                    moneys.Push(Money.TwoEuroCoin);
                    break;
                default:
                    throw new InvalidOperationException();

            }
        }
        
        // Act
        [When(@"I sum them")]
        public void WhenISumThem()
        {
            // push sum to the stack
            moneys.Push(moneys.Pop() + moneys.Pop());
        }
        
        // Assert
        [Then(@"the result should be (.*) eurocent on the screen")]
        public void ThenTheResultShouldBeEurocentOnTheScreen(int p0)
        {
            // peek sum from the stack
            Money sum = moneys.Peek();

            Decimal result = p0 * 0.01m;

            sum.Amount.Should().Be(result);
        }

    }
}
