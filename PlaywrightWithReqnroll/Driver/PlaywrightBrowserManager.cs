using Microsoft.Playwright;
using PlaywrightWithReqnroll.Configuration;

namespace PlaywrightWithReqnroll.Driver;

/// <summary>
/// Manages the initialization and configuration of browser instances using Playwright.
/// </summary>
public class PlaywrightBrowserManager(TestSettings testSettings) : IPlaywrightBrowserManager
{
    /// <summary>
    /// Retrieves a browser instance based on the specified browser type.
    /// </summary>
    /// <returns>An instance of <see cref="IBrowser"/> configured with the specified settings.</returns>
    public async Task<IBrowser> GetBrowserAsync()
    {
        var options = GetParameters();

        return await LaunchBrowserAsync(options);
    }

    /// <summary>
    /// Launches a browser instance based on the specified browser type and launch options.
    /// </summary>
    /// <param name="options">The launch options for the browser.</param>
    /// <returns>An instance of <see cref="IBrowser"/>.</returns>
    private async Task<IBrowser> LaunchBrowserAsync(BrowserTypeLaunchOptions options)
    {
        var playwright = await Playwright.CreateAsync();
        var bowserType = GetBrowserType(playwright);

        return await bowserType.LaunchAsync(options);
    }

    /// <summary>
    /// Configures the browser launch options based on the values from the run settings file.
    /// </summary>
    /// <returns>An instance of <see cref="BrowserTypeLaunchOptions"/> containing the configured options.</returns>
    private BrowserTypeLaunchOptions GetParameters()
    {
        return new BrowserTypeLaunchOptions
        {
            Headless = testSettings.Playwright.LaunchOptions.Headless,
            Channel = testSettings.Playwright.LaunchOptions.Channel,
        };
    }

    /// <summary>
    /// Retrieves the appropriate browser type from Playwright based on the browser specified in the run settings.
    /// </summary>
    /// <param name="playwright">The Playwright instance.</param>
    /// <returns>The browser type.</returns>
    private IBrowserType GetBrowserType(IPlaywright playwright)
    {
        var browserName = testSettings.Playwright.BrowserName;

        return browserName switch
        {
            "chromium" => playwright.Chromium,
            "firefox" => playwright.Firefox,
            "webkit" => playwright.Webkit,
            _ => throw new ArgumentOutOfRangeException(nameof(browserName), $"Unsupported browser type: {browserName}")
        };
    }
}

