using Microsoft.Playwright;

namespace PlaywrightWithReqnroll.RestClient;

/// <summary>
/// Defines a factory for creating <see cref="FluentRestClient"/> instances with various authentication options.
/// </summary>
public interface IRestClientFactory
{
    /// <summary>
    /// Creates a <see cref="FluentRestClient"/> configured with a JWT Bearer token for authentication.
    /// </summary>
    /// <param name="baseUrl">The base URL for the API requests.</param>
    /// <param name="bearerToken">The JWT Bearer token to use for authentication.</param>
    /// <returns>A <see cref="FluentRestClient"/> instance with JWT authentication.</returns>
    Task<FluentRestClient> CreateClientWithJWTToken(string baseUrl, string bearerToken);

    /// <summary>
    /// Creates a <see cref="FluentRestClient"/> configured with basic authentication credentials.
    /// </summary>
    /// <param name="baseUrl">The base URL for the API requests.</param>
    /// <param name="credentials">The HTTP credentials for basic authentication.</param>
    /// <returns>A <see cref="FluentRestClient"/> instance with basic authentication.</returns>
    Task<FluentRestClient> CreateClientWithBasicAuthentication(string baseUrl, HttpCredentials credentials);

    /// <summary>
    /// Creates a <see cref="FluentRestClient"/> without any authentication.
    /// </summary>
    /// <param name="baseUrl">The base URL for the API requests.</param>
    /// <returns>A <see cref="FluentRestClient"/> instance without authentication.</returns>
    Task<FluentRestClient> CreateUnauthenticatedClient(string baseUrl);
}