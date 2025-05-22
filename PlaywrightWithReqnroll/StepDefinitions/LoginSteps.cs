using PlaywrightWithReqnroll.Configuration;
using PlaywrightWithReqnroll.Models;
using PlaywrightWithReqnroll.Pages;
using Reqnroll;

[Binding]
public class LoginSteps(
    ScenarioDataContext scenarioDataContext, 
    LoginPage loginPage, 
    TestSettings testSettings)
{

    [Given("I navigate to the saucedemo.com")]
    public async Task GivenINavigateToTheSaucedemo_Com()
    {
        await loginPage.NavigateToUrlAsync(testSettings.ApplicationBaseUrl);
    }

    [When("I login with credentials:")]
    public async Task WhenILoginWithCredentials(LoginCredentials loginCredentials)
    {
        scenarioDataContext.LoginCredentials = loginCredentials;
        await loginPage.LoginAsync(loginCredentials);
    }
}
