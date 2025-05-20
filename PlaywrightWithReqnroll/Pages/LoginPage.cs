using Microsoft.Playwright;
using PlaywrightWithReqnroll.Models;

namespace PlaywrightWithReqnroll.Pages;

/// <summary>
/// Represents the login page and provides methods to perform login actions using Playwright.
/// </summary>
public class LoginPage(IPage page)
{
    private readonly IPage _page = page;

    private ILocator UsernameInput => _page.GetByPlaceholder("Username");
    private ILocator PasswordInput => _page.GetByPlaceholder("Password");
    private ILocator LoginButton => _page.Locator("#login-button");

    /// <summary>
    /// Navigates the browser page to the specified URL.
    /// </summary>
    /// <param name="url">The URL to navigate to.</param>
    /// <returns>A task that represents the asynchronous navigation operation.</returns>
    public async Task NavigateToUrlAsync(string url)
    {
        await _page.GotoAsync(url);
    }

    /// <summary>
    /// Performs the login action by filling in the username and password fields and clicking the login button.
    /// </summary>
    /// <param name="loginCredentials">The credentials to use for logging in.</param>
    /// <returns>A task that represents the asynchronous login operation.</returns>
    public async Task LoginAsync(LoginCredentials loginCredentials)
    {
        await UsernameInput.FillAsync(loginCredentials.Username);
        await PasswordInput.FillAsync(loginCredentials.Password);
        await LoginButton.ClickAsync();
    }
}