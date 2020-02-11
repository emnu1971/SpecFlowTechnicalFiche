using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace GameCore.Specs.StepDefinitions
{
    [Binding]
    public class MaintenanceSteps
    {

        [Given(@"I'm in maintenance for (.*) seconds")]
        public void GivenIMInMaintenanceForSeconds(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

    }
}
