using FluentAssertions;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using VendingMachine.Domain;
using static VendingMachine.Domain.Money;

namespace VendingMachine.Tests.SpecFlow.StepDefinitions
{
    [Binding]
    public class VendingMachineTestSteps
    {
        private readonly VendingMachine.Domain.VendingMachine _vendingMachine = new VendingMachine.Domain.VendingMachine();
        private readonly MoneyStepsContext _moneyStepsContext;

        public VendingMachineTestSteps(MoneyStepsContext moneyStepsContext)
        {
            this._moneyStepsContext = moneyStepsContext;
        }

        [Given(@"I have entered (.*) cent into the vending machine")]
        public void GivenIHaveEnteredCentIntoTheVendingMachine(int centOrCoin)
        {
            _vendingMachine.InsertMoney(ReturnAmountOfMoney(centOrCoin));
        }

        [Given(@"I push the return money button")]
        public void GivenIPushTheReturnMoneyButton()
        {
            _vendingMachine.ReturnMoney();
        }

        [Given(@"I have simultanuousely entered (.*) cent and (.*) cent into the vending machine")]
        public void GivenIHaveSimultanuouselyEnteredCentAndCentIntoTheVendingMachine(int centOrCoin1, int centOrCoin2)
        {
            var money1 = ReturnAmountOfMoney(centOrCoin1);
            var money2 = ReturnAmountOfMoney(centOrCoin2);
            var doubleMoney = money1 + money2;
            this._moneyStepsContext.DoubleMoney = doubleMoney;

        }

        [Then(@"An invalid operation exception should be thrown by the vending machine")]
        public void ThenAnInvalidOperationExceptionShouldBeThrownByTheVendingMachine()
        {
            Action action = () => _vendingMachine.InsertMoney(this._moneyStepsContext.DoubleMoney);
            action.Should().Throw<InvalidOperationException>();
        }


        [Then(@"Vending machine money in transaction should be (.*) cent")]
        public void ThenVendingMachineMoneyInTransactionShouldBeCent(int expectedAmountOfMoney)
        {
            decimal expectedAmountOfMoneyDecimal = expectedAmountOfMoney * 0.01m;
            _vendingMachine.MoneyInTransaction.Amount.Should().Be(expectedAmountOfMoneyDecimal);
        }


        private Money ReturnAmountOfMoney(int centOrCoin)
        {
            switch (centOrCoin)
            {
                case 5:
                    return FiveEuroCent;
                case 10:
                    return TenEuroCent;
                case 20:
                    return TwentyEuroCent;
                case 50:
                    return FiftyEuroCent;
                case 1:
                    return OneEuroCoin;
                case 2:
                    return TwoEuroCoin;
                default:
                    return None;
            }
        }
    }
}
