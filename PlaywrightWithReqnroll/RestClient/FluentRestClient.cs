﻿using Microsoft.Playwright;

namespace PlaywrightWithReqnroll.RestClient;

/// <summary>
/// Provides a fluent interface for building and executing HTTP requests using Playwright's <see cref="IAPIRequestContext"/>.
/// </summary>
public class FluentRestClient(IAPIRequestContext context) : IFluentRestClient, IDisposable, IAsyncDisposable
{
    private string _url = string.Empty;
    private readonly APIRequestContextOptions _options = new() { Timeout = 90000 };
    private bool _isDisposed;

    /// <summary>
    /// Sets the URL for the HTTP request.
    /// </summary>
    /// <param name="url">The request URL.</param>
    /// <returns>The current <see cref="FluentRestClient"/> instance for method chaining.</returns>
    public FluentRestClient WithUrl(string url)
    {
        _url = url;
        return this;
    }

    /// <summary>
    /// Sets the HTTP headers for the request.
    /// </summary>
    /// <param name="headers">A dictionary of header names and values.</param>
    /// <returns>The current <see cref="FluentRestClient"/> instance for method chaining.</returns>
    public FluentRestClient WithHeaders(Dictionary<string, string> headers)
    {
        var newHeaders = _options.Headers?.ToDictionary(h => h.Key, h => h.Value) ?? [];

        foreach (var header in headers)
        {
            newHeaders[header.Key] = header.Value;
        }

        _options.Headers = newHeaders;
        return this;
    }

    /// <summary>
    /// Sets the query parameters for the HTTP request.
    /// </summary>
    /// <param name="queryParams">A dictionary of query parameter names and values.</param>
    /// <returns>The current <see cref="FluentRestClient"/> instance for method chaining.</returns>
    public FluentRestClient WithParams(Dictionary<string, object> queryParams)
    {
        _options.Params = queryParams;
        return this;
    }

    /// <summary>
    /// Sets the request body for the HTTP request.
    /// </summary>
    /// <param name="body">The body object to be serialized and sent with the request.</param>
    /// <returns>The current <see cref="FluentRestClient"/> instance for method chaining.</returns>
    public FluentRestClient WithBody(object body)
    {
        _options.DataObject = body;
        return this;
    }

    /// <summary>
    /// Executes an HTTP GET request with the configured parameters.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the API response.</returns>
    public async Task<IAPIResponse> ExecuteGetAsync() => await context.GetAsync(_url, _options);

    /// <summary>
    /// Executes an HTTP POST request with the configured parameters and body.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the API response.</returns>
    public async Task<IAPIResponse> ExecutePostAsync() => await context.PostAsync(_url, _options);

    /// <summary>
    /// Executes an HTTP PUT request with the configured parameters and body.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the API response.</returns>
    public async Task<IAPIResponse> ExecutePutAsync() => await context.PutAsync(_url, _options);

    /// <summary>
    /// Executes an HTTP PATCH request with the configured parameters and body.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the API response.</returns>
    public async Task<IAPIResponse> ExecutePatchAsync() => await context.PatchAsync(_url, _options);

    /// <summary>
    /// Executes an HTTP DELETE request with the configured parameters.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the API response.</returns>
    public async Task<IAPIResponse> ExecuteDeleteAsync() => await context.DeleteAsync(_url, _options);

    /// <summary>
    /// Asynchronously disposes the underlying <see cref="IAPIRequestContext"/> and releases any associated resources.
    /// </summary>
    /// <returns>A <see cref="ValueTask"/> that represents the asynchronous dispose operation.</returns>
    public async ValueTask DisposeAsync()
    {
        if (_isDisposed) return;

        await context.DisposeAsync();
        _isDisposed = true;
    }

    /// <summary>
    /// Synchronously disposes the Playwright driver and releases all associated resources.
    /// This method blocks until the asynchronous disposal operation is complete by calling <see cref="DisposeAsync"/>.
    /// </summary>
    public void Dispose()
    {
        DisposeAsync().GetAwaiter().GetResult();
    }
}