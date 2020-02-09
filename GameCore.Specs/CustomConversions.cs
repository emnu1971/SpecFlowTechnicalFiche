using System;
using TechTalk.SpecFlow;

namespace GameCore.Specs
{
    /// <summary>
    /// Author      : Emmanuel Nuyttens
    /// Date        : 02-2020
    /// Purpose     : Custom conversions class
    /// </summary>
    [Binding]
    public class CustomConversions
    {
        [StepArgumentTransformation(@"(\d+) days ago")]
        public DateTime DaysAgoTransformation(int daysAgo)
        {
            return DateTime.Now.Subtract(TimeSpan.FromDays(daysAgo));
        }
    }
}
