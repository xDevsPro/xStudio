using TechTalk.SpecFlow;
using Xunit;

namespace xStudio.UITests.Steps
{
    [Binding]
    public class SanitySteps
    {
        [Given(@"Setup the environment")]
        public void GivenSetupTheEnvironment()
        {
        }

        [When(@"App Run")]
        public void WhenAppRun()
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
