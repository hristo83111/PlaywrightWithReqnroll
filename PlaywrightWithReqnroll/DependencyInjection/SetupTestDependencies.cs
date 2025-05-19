using Microsoft.Extensions.DependencyInjection;
using PlaywrightWithReqnroll.Driver;
using PlaywrightWithReqnroll.RestClient;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

public class SetupTestDependencies
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();

        services.AddScoped<IPlaywrightBrowserManager, PlaywrightBrowserManager>();
        services.AddScoped<IPlaywrightDriver, PlaywrightDriver>();
        services.AddSingleton<IRestClientFactory, RestClientFactory>();

        return services;
    }
}

