using Microsoft.Playwright;
using PlaywrightWithReqnroll.Driver;

namespace PlaywrightWithReqnroll.RestClient;

/// <summary>
/// Factory for creating <see cref="FluentRestClient"/> instances with various authentication options.
/// </summary>
public class RestClientFactory : IRestClientFactory
{
    // Use your LazyAsync<T> for singleton async initialization
    private static readonly LazyAsync<IPlaywright> _playwright = new(() => Playwright.CreateAsync());

    /// <summary>
    /// Creates a <see cref="FluentRestClient"/> configured with a JWT Bearer token for authentication.
    /// </summary>
    /// <param name="baseUrl">The base URL for the API requests.</param>
    /// <param name="bearerToken">The JWT Bearer token to use for authentication.</param>
    /// <returns>A <see cref="FluentRestClient"/> instance with JWT authentication.</returns>
    public Task<FluentRestClient> CreateClientWithJWTTokenAsync(string baseUrl, string bearerToken) =>
        CreateClientAsync(baseUrl, extraHeaders: new Dictionary<string, string> { { "Authorization", $"Bearer {bearerToken}" } });

    /// <summary>
    /// Creates a <see cref="FluentRestClient"/> configured with basic authentication credentials.
    /// </summary>
    /// <param name="baseUrl">The base URL for the API requests.</param>
    /// <param name="credentials">The HTTP credentials for basic authentication.</param>
    /// <returns>A <see cref="FluentRestClient"/> instance with basic authentication.</returns>
    public Task<FluentRestClient> CreateClientWithBasicAuthenticationAsync(string baseUrl, HttpCredentials credentials) =>
        CreateClientAsync(baseUrl, credentials: credentials);

    /// <summary>
    /// Creates a <see cref="FluentRestClient"/> without any authentication.
    /// </summary>
    /// <param name="baseUrl">The base URL for the API requests.</param>
    /// <returns>A <see cref="FluentRestClient"/> instance without authentication.</returns>
    public Task<FluentRestClient> CreateUnauthenticatedClientAsync(string baseUrl) =>
        CreateClientAsync(baseUrl);

    /// <summary>
    /// Internal helper to create a <see cref="FluentRestClient"/> with optional headers and credentials.
    /// </summary>
    /// <param name="baseUrl">The base URL for the API requests.</param>
    /// <param name="extraHeaders">Optional extra HTTP headers.</param>
    /// <param name="credentials">Optional HTTP credentials for authentication.</param>
    /// <returns>A <see cref="FluentRestClient"/> instance.</returns>
    private async Task<FluentRestClient> CreateClientAsync(
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
}