using FluentAssertions;
using VendingMachine.Domain;
using Xunit;

namespace VendingMachines.Tests.Traditional
{
    public class MoneyTests
    {
        [Fact]
        public void Sum_of_two_moneys_produces_correct_result()
        {
            // Arrange
            Money money1 = Money.FiftyEuroCent;
            Money money2 = Money.TwentyEuroCent;

            // Act
            Money sum = money1 + money2;

            // Assert
            sum.Amount.Should().Be(0.70m);

        }
    }
}
