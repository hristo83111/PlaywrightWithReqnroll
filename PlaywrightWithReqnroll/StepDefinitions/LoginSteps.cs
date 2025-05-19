using Microsoft.Playwright;
using PlaywrightWithReqnroll.Driver;
using Reqnroll;

namespace PlaywrightWithReqnroll.StepDefinitions;

[Binding]
public class LoginSteps(IPlaywrightDriver playwrightDriver)
{
    private readonly IPage _page = playwrightDriver.Page.Result;

    [Given("I navigate to the conduit.bondaracademy.com")]
    public async Task GivenINavigateToTheConduit_Bondaracademy_ComAsync()
    {
        await _page.GotoAsync("https://google.com");
    }

    [When("I enter {string} and {string}")]
    public void WhenIEnterAnd(string username, string password)
    {
        throw new PendingStepException();
    }

    [When("I click the login button")]
    public void WhenIClickTheLoginButton()
    {
        throw new PendingStepException();
    }

    [Then("I should be logged in successfully")]
    public void ThenIShouldBeLoggedInSuccessfully()
    {
        throw new PendingStepException();
    }
}

