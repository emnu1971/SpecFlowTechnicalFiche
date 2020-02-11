using TechTalk.SpecFlow;

namespace GameCore.Specs
{
    /// <summary>
    /// Author  : Emmanuel Nuyttens
    /// Date    : 02-2012
    /// Purpose : Additional code hooks class
    /// Info    : Inherit from Steps base class which gives access to 
    ///           a thread safe ScenarioInfo
    /// </summary>
    [Binding]
    public class AdditionalCodeHooks : Steps
    {
        [BeforeScenario("undocked")]
        public void BeforeScenario()
        {
            //TODO: Add code which should be executed before scenario start
        }

        [AfterScenario("undocked")]
        public void AfterScenario()
        {
            //TODO: Add code which should be executed after scenario ends
        }

    }
}
