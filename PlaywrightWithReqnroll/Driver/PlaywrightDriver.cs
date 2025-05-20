using Microsoft.Playwright;

namespace PlaywrightWithReqnroll.Driver;

/// <summary>
/// Provides a driver for managing Playwright browser instances, contexts, and pages.
/// </summary>
public class PlaywrightDriver : IPlaywrightDriver, IDisposable, IAsyncDisposable
{
    private readonly IPlaywrightBrowserManager _playwrightBrowserManager;
    private readonly LazyAsync<IBrowser> _browser;
    private readonly LazyAsync<IBrowserContext> _browserContext;
    private readonly LazyAsync<IPage> _page;
    private bool _isDisposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightDriver"/> class.
    /// </summary>
    /// <param name="playwrightBrowserManager">The browser manager used to initialize the Playwright browser instance.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="playwrightBrowserManager"/> is null.</exception>
    public PlaywrightDriver(IPlaywrightBrowserManager playwrightBrowserManager)
    {
        _playwrightBrowserManager = playwrightBrowserManager
            ?? throw new ArgumentNullException(nameof(playwrightBrowserManager));
        _browser = new LazyAsync<IBrowser>(CreateBrowserAsync);
        _browserContext = new LazyAsync<IBrowserContext>(CreateBrowserContextAsync);
        _page = new LazyAsync<IPage>(CreatePageAsync);
    }

    /// <summary>
    /// Gets the Playwright browser instance, lazily initialized.
    /// </summary>
    public Task<IBrowser> Browser => _browser.Value;

    /// <summary>
    /// Gets the Playwright browser context, lazily initialized.
    /// </summary>
    public Task<IBrowserContext> BrowserContext => _browserContext.Value;

    /// <summary>
    /// Gets the Playwright page instance, lazily initialized.
    /// </summary>
    public Task<IPage> Page => _page.Value;

    /// <summary>
    /// Disposes of the Playwright browser instance and releases resources.
    /// </summary>
    public async ValueTask DisposeAsync()
    {
        if (_isDisposed) return;

        if (_browser.IsValueCreated)
        {
            var browser = await Browser;
            await browser.CloseAsync();
            await browser.DisposeAsync();
        }

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

    /// <summary>
    /// Initializes the Playwright browser asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the initialized <see cref="IBrowser"/> instance.</returns>
    private async Task<IBrowser> CreateBrowserAsync()
        => await _playwrightBrowserManager.GetBrowserAsync();

    /// <summary>
    /// Creates a new browser context asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="IBrowserContext"/> instance.</returns>
    private async Task<IBrowserContext> CreateBrowserContextAsync()
        => await (await _browser).NewContextAsync();

    /// <summary>
    /// Creates a new page within the browser context asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the created <see cref="IPage"/> instance.</returns>
    private async Task<IPage> CreatePageAsync()
        => await (await _browserContext).NewPageAsync();
}

