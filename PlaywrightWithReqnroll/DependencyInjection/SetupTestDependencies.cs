using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;
using PlaywrightWithReqnroll.Configuration;
using PlaywrightWithReqnroll.Driver;
using PlaywrightWithReqnroll.Models;
using PlaywrightWithReqnroll.Pages;
using PlaywrightWithReqnroll.RestClient;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides dependency injection setup for test services used in PlaywrightWithReqnroll.
/// </summary>
public class SetupTestDependencies
{
    /// <summary>
    /// Registers all required services for test execution, including configuration, Playwright drivers, browser contexts, and page objects.
    /// </summary>
    /// <returns>An <see cref="IServiceCollection"/> containing all registered test services.</returns>
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();

        services
            .AddSingleton<IRestClientFactory, RestClientFactory>()
            .AddSingleton<TestSettings>(_ => ConfigurationLoader.Load())
            .AddScoped<IPlaywrightBrowserManager, PlaywrightBrowserManager>()
            .AddScoped<IPlaywrightDriver, PlaywrightDriver>()
            .AddScoped<ScenarioDataContext>()
            .AddScoped<LoginPage>()
            .AddScoped<InventoryPage>();

        return services;
    }
}