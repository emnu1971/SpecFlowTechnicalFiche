using VendingMachine.Domain;

namespace VendingMachine.Tests.SpecFlow
{
    /// <summary>
    /// Author      : Emmanuel Nuyttens
    /// Date        : 02-2020
    /// Purpose     : Share context data between definition steps
    /// </summary>
    public class MoneyStepsContext
    {
        public int NumberOfInvalidOperationExceptions { get; set; }

        public Money DoubleMoney { get; set; }
    }
}
