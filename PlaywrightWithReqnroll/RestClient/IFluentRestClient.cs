using Microsoft.Playwright;

namespace PlaywrightWithReqnroll.RestClient
{
    /// <summary>
    /// Defines a fluent interface for building and executing HTTP requests using Playwright's APIRequestContext.
    /// </summary>
    public interface IFluentRestClient
    {
        /// <summary>
        /// Executes an HTTP DELETE request with the configured parameters.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the API response.</returns>
        Task<IAPIResponse> ExecuteDeleteAsync();

        /// <summary>
        /// Executes an HTTP GET request with the configured parameters.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the API response.</returns>
        Task<IAPIResponse> ExecuteGetAsync();

        /// <summary>
        /// Executes an HTTP PATCH request with the configured parameters and body.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the API response.</returns>
        Task<IAPIResponse> ExecutePatchAsync();

        /// <summary>
        /// Executes an HTTP POST request with the configured parameters and body.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the API response.</returns>
        Task<IAPIResponse> ExecutePostAsync();

        /// <summary>
        /// Executes an HTTP PUT request with the configured parameters and body.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the API response.</returns>
        Task<IAPIResponse> ExecutePutAsync();

        /// <summary>
        /// Sets the request body for the HTTP request.
        /// </summary>
        /// <param name="body">The body object to be serialized and sent with the request.</param>
        /// <returns>The current <see cref="FluentRestClient"/> instance for method chaining.</returns>
        FluentRestClient WithBody(object body);

        /// <summary>
        /// Sets the HTTP headers for the request.
        /// </summary>
        /// <param name="headers">A dictionary of header names and values.</param>
        /// <returns>The current <see cref="FluentRestClient"/> instance for method chaining.</returns>
        FluentRestClient WithHeaders(Dictionary<string, string> headers);

        /// <summary>
        /// Sets the query parameters for the HTTP request.
        /// </summary>
        /// <param name="queryParams">A dictionary of query parameter names and values.</param>
        /// <returns>The current <see cref="FluentRestClient"/> instance for method chaining.</returns>
        FluentRestClient WithParams(Dictionary<string, object> queryParams);

        /// <summary>
        /// Sets the URL for the HTTP request.
        /// </summary>
        /// <param name="url">The request URL.</param>
        /// <returns>The current <see cref="FluentRestClient"/> instance for method chaining.</returns>
        FluentRestClient WithUrl(string url);
    }
}