using TechTalk.SpecFlow;
using Xunit;

namespace xStudio.SpecTests.Steps
{
    [Binding]
    public class SanitySteps
    {
        [Given(@"Setup the environment")]
        public void GivenSetupTheEnvironment()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Test Run")]
        public void WhenTestRun()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Pass")]
        public void ThenPass()
        {
            Assert.True(true);
        }
    }
}
