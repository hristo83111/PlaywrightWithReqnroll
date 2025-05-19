using Microsoft.Playwright;
using PlaywrightWithReqnroll.Driver;

namespace PlaywrightWithReqnroll.RestClient;

/// <summary>
/// Factory for creating <see cref="FluentRestClient"/> instances with various authentication options.
/// </summary>
public class RestClientFactory : IRestClientFactory
{
    private readonly LazyAsync<IPlaywright> _playwright;
    private bool _isDisposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="RestClientFactory"/> class.
    /// </summary>
    public RestClientFactory()
    {
        _playwright = new LazyAsync<IPlaywright>(CreatePlaywrightAsync);
    }

    /// <inheritdoc />
    public Task<FluentRestClient> CreateClientWithJWTToken(string baseUrl, string bearerToken) =>
        CreateClient(baseUrl, extraHeaders: new Dictionary<string, string> { { "Authorization", $"Bearer {bearerToken}" } });

    /// <inheritdoc />
    public Task<FluentRestClient> CreateClientWithBasicAuthentication(string baseUrl, HttpCredentials credentials) =>
        CreateClient(baseUrl, credentials: credentials);

    /// <inheritdoc />
    public Task<FluentRestClient> CreateUnauthenticatedClient(string baseUrl) =>
        CreateClient(baseUrl);

    /// <summary>
    /// Internal helper to create a <see cref="FluentRestClient"/> with optional headers and credentials.
    /// </summary>
    private async Task<FluentRestClient> CreateClient(
        string baseUrl,
        Dictionary<string, string>? extraHeaders = null,
        HttpCredentials? credentials = null)
    {
        var playwright = await _playwright;
        var options = new APIRequestNewContextOptions
        {
            BaseURL = baseUrl,
            IgnoreHTTPSErrors = true,
            ExtraHTTPHeaders = extraHeaders,
            HttpCredentials = credentials
        };
        var context = await playwright.APIRequest.NewContextAsync(options);
        return new FluentRestClient(context);
    }

    /// <summary>
    /// Creates the Playwright instance asynchronously.
    /// </summary>
    private static Task<IPlaywright> CreatePlaywrightAsync() => Playwright.CreateAsync();

    /// <summary>
    /// Disposes of the Playwright instance and releases resources.
    /// </summary>
    public void Dispose()
    {
        if (_isDisposed) return;

        if (_playwright.IsValueCreated)
        {
            Task.Run(async () =>
            {
                var playwright = await _playwright;
                playwright.Dispose();
            });
        }

        _isDisposed = true;
    }
}