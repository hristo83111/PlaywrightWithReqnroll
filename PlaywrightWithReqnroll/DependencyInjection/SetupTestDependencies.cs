using CoreFramework.Config;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;
using PlaywrightWithReqnroll.Configuration;
using PlaywrightWithReqnroll.Driver;
using PlaywrightWithReqnroll.Pages;
using PlaywrightWithReqnroll.RestClient;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

public class SetupTestDependencies
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();

        IPlaywrightDriver GetDriver(IServiceProvider provider) =>
            provider.GetRequiredService<IPlaywrightDriver>();

        services
            .AddSingleton<IRestClientFactory, RestClientFactory>()
            .AddSingleton<TestSettings>(_ => ConfigReader.ReadConfig())
            .AddScoped<IPlaywrightBrowserManager, PlaywrightBrowserManager>()
            .AddScoped<IPlaywrightDriver, PlaywrightDriver>()
            .AddScoped<IBrowser>(provider => GetDriver(provider).Browser.Result)
            .AddScoped<IBrowserContext>(provider => GetDriver(provider).BrowserContext.Result)
            .AddScoped<IPage>(provider => GetDriver(provider).Page.Result)
            .AddScoped<LoginPage>()
            .AddScoped<InventoryPage>();

        return services;
    }
}

