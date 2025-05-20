using PlaywrightWithReqnroll.Configuration;
using PlaywrightWithReqnroll.Models;
using PlaywrightWithReqnroll.Pages;
using Reqnroll;

[Binding]
public class LoginSteps(LoginPage loginPage, TestSettings testSettings)
{
    private readonly LoginPage _loginPage = loginPage;
    private readonly TestSettings _testSettings = testSettings;

    [Given("I navigate to the saucedemo.com")]
    public async Task GivenINavigateToTheSaucedemo_Com()
    {
        await _loginPage.NavigateToUrlAsync(_testSettings.ApplicationBaseUrl);
    }

    [When("I login with credentials:")]
    public async Task WhenILoginWithCredentials(LoginCredentials loginCredentials)
    {
        await _loginPage.LoginAsync(loginCredentials);
    }
}
