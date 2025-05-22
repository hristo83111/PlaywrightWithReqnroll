using PlaywrightWithReqnroll.Driver;
using PlaywrightWithReqnroll.Models;

namespace PlaywrightWithReqnroll.Pages;

/// <summary>
/// Represents the login page and provides methods to perform login actions using Playwright.
/// </summary>
public class LoginPage(IPlaywrightDriver playwrightDriver)
{
    /// <summary>
    /// Navigates the browser page to the specified URL.
    /// </summary>
    /// <param name="url">The URL to navigate to.</param>
    /// <returns>A task that represents the asynchronous navigation operation.</returns>
    public async Task NavigateToUrlAsync(string url)
    {
        var page = await playwrightDriver.Page;
        await page.GotoAsync(url);
    }

    /// <summary>
    /// Performs the login action by filling in the username and password fields and clicking the login button.
    /// </summary>
    /// <param name="loginCredentials">The credentials to use for logging in.</param>
    /// <returns>A task that represents the asynchronous login operation.</returns>
    public async Task LoginAsync(LoginCredentials loginCredentials)
    {
        var page = await playwrightDriver.Page;
        var usernameInput = page.GetByPlaceholder("Username");
        var passwordInput = page.GetByPlaceholder("Password");
        var loginButton = page.Locator("#login-button");

        await usernameInput.FillAsync(loginCredentials.Username);
        await passwordInput.FillAsync(loginCredentials.Password);
        await loginButton.ClickAsync();
    }
}