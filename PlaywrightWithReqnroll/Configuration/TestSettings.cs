namespace PlaywrightWithReqnroll.Configuration;

/// <summary>
/// Represents the configuration settings for test execution.
/// </summary>
public class TestSettings
{
    /// <summary>
    /// Gets or sets the application base URL to be tested.
    /// </summary>
    public string ApplicationBaseUrl { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the API base URL to be tested.
    /// </summary>
    public string APIBaseUrl { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Playwright-specific configuration settings for browser automation.
    /// </summary>
    public PlaywrightSettings Playwright { get; set; } = new();

    /// <summary>
    /// Gets or sets the database connection strings for the test execution.
    /// </summary>
    public ConnectionStrings ConnectionStrings { get; set; } = new();
}

/// <summary>
/// Represents the database connection strings for different databases.
/// </summary>
public class ConnectionStrings
{
    /// <summary>
    /// Gets or sets the connection string for the Sales database.
    /// </summary>
    public string SalesDb { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the connection string for the Inventory database.
    /// </summary>
    public string InventoryDb { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the connection string for the Support database.
    /// </summary>
    public string SupportDb { get; set; } = string.Empty;
}

/// <summary>
/// Represents Playwright-specific configuration settings for browser automation.
/// </summary>
public class PlaywrightSettings
{
    /// <summary>
    /// Gets or sets the name of the browser to use for test execution (e.g., "chromium", "firefox", "webkit").
    /// </summary>
    public string BrowserName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the browser launch options, such as headless mode and browser channel.
    /// </summary>
    public LaunchOptions LaunchOptions { get; set; } = new();
}

/// <summary>
/// Represents options for launching a Playwright browser instance.
/// </summary>
public class LaunchOptions
{
    /// <summary>
    /// Gets or sets a value indicating whether the browser should be launched in headless mode.
    /// </summary>
    public bool Headless { get; set; }

    /// <summary>
    /// Gets or sets the browser channel to use (e.g., "chrome", "msedge"). Leave empty for the default channel.
    /// </summary>
    public string Channel { get; set; } = string.Empty;
}