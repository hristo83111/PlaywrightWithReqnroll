using Reqnroll;

namespace PlaywrightWithReqnroll.Hooks;

[Binding]
public sealed class Hooks()
{
    [BeforeScenario]
    public void BeforeScenario()
    {
        //TODO: implement logic that has to run after executing each scenario
    }

    [AfterScenario]
    public void AfterScenario()
    {
        //TODO: implement logic that has to run after executing each scenario
    }
}