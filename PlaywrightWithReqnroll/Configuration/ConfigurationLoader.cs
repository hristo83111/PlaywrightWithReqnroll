using Microsoft.Extensions.Configuration;

namespace PlaywrightWithReqnroll.Configuration;

/// <summary>
/// Provides functionality to load and bind test configuration settings from JSON files and command-line arguments.
/// </summary>
public static class ConfigurationLoader
{
    /// <summary>
    /// Loads the <see cref="TestSettings"/> from configuration sources.
    /// It reads from 'appsettings.json', an optional environment-specific JSON file, and command-line arguments.
    /// The environment is determined by the 'Environment' environment variable, defaulting to 'QA' if not set.
    /// </summary>
    /// <param name="args">Optional command-line arguments to include in the configuration.</param>
    /// <returns>A populated <see cref="TestSettings"/> instance.</returns>
    public static TestSettings Load()
    {
        var environment = Environment.GetEnvironmentVariable("Environment") ?? "QA";

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var settings = new TestSettings();
        config.Bind(settings);
        return settings;
    }
}
