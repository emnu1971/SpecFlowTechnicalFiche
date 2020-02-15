using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using VendingMachine.Domain;
using static VendingMachine.Domain.Money;

namespace VendingMachine.Tests.SpecFlow.StepDefinitions
{
    [Binding]
    public class MoneyTestSteps

    {
        private readonly Stack<Money> _moneys = new Stack<Money>();
        private readonly MoneyStepsContext _moneyStepsContext;

        public MoneyTestSteps(MoneyStepsContext moneyStepsContext)
        {
            this._moneyStepsContext = moneyStepsContext;
        }

        
        // Arrange
        [Given(@"I have entered (.*) eurocent into the money object")]
        public void GivenIHaveEnteredEurocentIntoTheMoneyObject(int p0)
        {
            
            // push money amount on the stack
            switch (p0)
            {
                case 5:
                    // 5eurocent
                    _moneys.Push(Money.FiveEuroCent);
                    break;
                case 10:
                    // 10eurocent
                    _moneys.Push(Money.TenEuroCent);
                    break;
                case 20:
                    // 20eurocent
                    _moneys.Push(Money.TwentyEuroCent);
                    break;
                case 50:
                    // 50eurocent
                    _moneys.Push(Money.FiftyEuroCent);
                    break;
                case 1:
                    // 1eurocoin
                    _moneys.Push(Money.OneEuroCoin);
                    break;
                case 2:
                    // 2eurocoin
                    _moneys.Push(Money.TwoEuroCoin);
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
            _moneys.Push(_moneys.Pop() + _moneys.Pop());
        }
        
        // Assert
        [Then(@"the result should be (.*) eurocent on the screen")]
        public void ThenTheResultShouldBeEurocentOnTheScreen(int p0)
        {
            // peek sum from the stack
            Money sum = _moneys.Peek();

            Decimal result = p0 * 0.01m;

            sum.Amount.Should().Be(result);
        }

        [Given(@"I have (.*) twenty cents and (.*) ten cents")]
        public void GivenIHaveTwentyCentsAndTenCents(int twentyCentCount, int tenCentCount)
        {
            Money money = new Money(0,tenCentCount,twentyCentCount,0,0,0);
            _moneys.Push(money);
        }

        [Given(@"my friend has (.*) ten cent and (.*) twenty cents and (.*) fifty cent")]
        public void GivenMyFriendHasTenCentAndTwentyCentsAndFiftyCent(int tenCentCount, int twentyCentCount, int fiftyCentCount)
        {
            Money money = new Money(0, tenCentCount, twentyCentCount, fiftyCentCount, 0, 0);
            _moneys.Push(money);
        }

        [Then(@"we both have the same amount of money which is (.*) euro in total")]
        public void ThenWeBothHaveTheSameAmountOfMoneyWhichIsEuro(decimal expectedAmount)
        {
            _moneys.Push(_moneys.Pop() + _moneys.Pop());
            Money sum = _moneys.Peek();
            sum.Amount.Should().Be(expectedAmount);

        }

        [Given(@"I have the following money items (Custom)")]
        public void GivenIHaveTheFollowingMoneyItems_Custom(IEnumerable<MoneyType> moneyTypes)
        {
            int numberOfExceptions = 0;
            Money money = None;

            foreach(var moneyType in moneyTypes)
            {
                switch (moneyType.Name)
                {
                    case "fivecent":
                        try

                        {
                            money = new Money(moneyType.Value, 0, 0, 0, 0, 0);
                        }
                        catch (InvalidOperationException)
                        {
                            numberOfExceptions++;
                        }
                        break;
                    case "tencent":
                        try

                        {
                            money = new Money(0, moneyType.Value, 0, 0, 0, 0);
                        }
                        catch (InvalidOperationException)
                        {
                            numberOfExceptions++;
                        }
                        break;
                    case "twentycent":
                        try

                        {
                            money = new Money(0, 0, moneyType.Value, 0, 0, 0);
                        }
                        catch (InvalidOperationException)
                        {
                            numberOfExceptions++;
                        }
                        break;
                    case "fiftycent":
                        try

                        {
                            money = new Money(0, 0, 0, moneyType.Value, 0, 0);
                        }
                        catch (InvalidOperationException)
                        {
                            numberOfExceptions++;
                        }
                        break;
                    case "oneeuro":
                        try

                        {
                            money = new Money(0, 0, 0, 0, moneyType.Value, 0);
                        }
                        catch (InvalidOperationException)
                        {
                            numberOfExceptions++;
                        }
                        break;
                    case "twoeuro":
                        try

                        {
                            money = new Money(0, 0, 0, 0, 0, moneyType.Value);
                        }
                        catch (InvalidOperationException)
                        {
                            numberOfExceptions++;
                        }
                        break;
                }
            }
            this._moneyStepsContext.NumberOfInvalidOperationExceptions = numberOfExceptions;
        }

        
        


        [Given(@"I have the following money items")]
        public void GivenIHaveTheFollowingMoneyItems(Table table)
        {
            List<MoneyType> moneyTypes = new List<MoneyType>();


            foreach(var row in table.Rows)
            {
                var name = row["name"];
                var value = row["value"];
                moneyTypes.Add(new MoneyType
                {
                    Name = name,
                    Value = int.Parse(value)
                });

            }

            int numberOfExceptions = 0;
            Money money = None;


            foreach (var moneyType in moneyTypes)
            {
                switch (moneyType.Name)
                {
                    case "fivecent":
                        try

                        {
                            money = new Money(moneyType.Value, 0, 0, 0, 0, 0);
                        }
                        catch (InvalidOperationException)
                        {
                            numberOfExceptions++;
                        }
                        break;
                    case "tencent":
                        try

                        {
                            money = new Money(0, moneyType.Value, 0, 0, 0, 0);
                        }
                        catch (InvalidOperationException)
                        {
                            numberOfExceptions++;
                        }
                        break;
                    case "twentycent":
                        try

                        {
                            money = new Money(0, 0, moneyType.Value, 0, 0, 0);
                        }
                        catch (InvalidOperationException)
                        {
                            numberOfExceptions++;
                        }
                        break;
                    case "fiftycent":
                        try

                        {
                            money = new Money(0, 0, 0, moneyType.Value, 0, 0);
                        }
                        catch (InvalidOperationException)
                        {
                            numberOfExceptions++;
                        }
                        break;
                    case "oneeuro":
                        try

                        {
                            money = new Money(0, 0, 0, 0, moneyType.Value, 0);
                        }
                        catch (InvalidOperationException)
                        {
                            numberOfExceptions++;
                        }
                        break;
                    case "twoeuro":
                        try

                        {
                            money = new Money(0, 0, 0, 0, 0, moneyType.Value);
                        }
                        catch (InvalidOperationException)
                        {
                            numberOfExceptions++;
                        }
                        break;
                }
            }
            this._moneyStepsContext.NumberOfInvalidOperationExceptions = numberOfExceptions;
        }



        [Then(@"(.*) invalid operation exception should be returned")]
        public void ThenInvalidOperationExceptionShouldBeReturned(int expectedNumberOfInvalidOperations)
        {
            _moneyStepsContext.NumberOfInvalidOperationExceptions.Should().Be(expectedNumberOfInvalidOperations);
        }

        [Scope(Tag = "moneysum")]
        [Given(@"I have the following money items")]
        public void GivenIHaveTheFollowingMoneyItems_Sum(Table table)
        {


            List<MoneyType> moneyTypes = new List<MoneyType>();

            foreach (var row in table.Rows)
            {
                var name = row["name"];
                var value = row["value"];
                moneyTypes.Add(new MoneyType
                {
                    Name = name,
                    Value = int.Parse(value)
                });

            }

            int numberOfExceptions = 0;

            foreach (var moneyType in moneyTypes)
            {
                switch (moneyType.Name)
                {
                    case "fivecent":
                        try

                        {

                            _moneys.Push(new Money(moneyType.Value, 0, 0, 0, 0, 0));
                        }
                        catch (InvalidOperationException)
                        {
                            numberOfExceptions++;
                        }
                        break;
                    case "tencent":
                        try

                        {
                            _moneys.Push(new Money(0, moneyType.Value, 0, 0, 0, 0));
                        }
                        catch (InvalidOperationException)
                        {
                            numberOfExceptions++;
                        }
                        break;
                    case "twentycent":
                        try

                        {
                            _moneys.Push(new Money(0, 0, moneyType.Value, 0, 0, 0));
                        }
                        catch (InvalidOperationException)
                        {
                            numberOfExceptions++;
                        }
                        break;
                    case "fiftycent":
                        try

                        {
                            _moneys.Push(new Money(0, 0, 0, moneyType.Value, 0, 0));
                        }
                        catch (InvalidOperationException)
                        {
                            numberOfExceptions++;
                        }
                        break;
                    case "oneeuro":
                        try

                        {
                            _moneys.Push(new Money(0, 0, 0, 0, moneyType.Value, 0));
                        }
                        catch (InvalidOperationException)
                        {
                            numberOfExceptions++;
                        }
                        break;
                    case "twoeuro":
                        try

                        {
                            _moneys.Push(new Money(0, 0, 0, 0, 0, moneyType.Value));
                        }
                        catch (InvalidOperationException)
                        {
                            numberOfExceptions++;
                        }
                        break;
                }
            }
            this._moneyStepsContext.NumberOfInvalidOperationExceptions = numberOfExceptions;
        }

        [Then(@"the sum of the moneys should be (.*) euro in total")]
        public void ThenTheSumOfTheMoneysShouldBeEuroInTotal(Decimal expectedTotalAmount)
        {
            Money totalMoney = None;

            while (_moneys.Count > 0)
            {
                totalMoney += _moneys.Pop();
            }

            totalMoney.Amount.Should().Be(expectedTotalAmount);

        }


    }
}
