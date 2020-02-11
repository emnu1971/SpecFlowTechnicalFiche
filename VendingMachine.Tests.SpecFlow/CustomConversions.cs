using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


namespace VendingMachine.Tests.SpecFlow
{
    /// <summary>
    /// Author  : Emmanuel Nuyttens
    /// Date    : 02-2012
    /// Purpose : Custom conversions class
    /// </summary>
    public class CustomConversions
    {
        [StepArgumentTransformation]
        public IEnumerable<MoneyType> MoneyTypeTransformation(Table table)
        {
            var moneyTypes = table.CreateSet<MoneyType>();

            return moneyTypes;
        }
    }

    public class MoneyType
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
