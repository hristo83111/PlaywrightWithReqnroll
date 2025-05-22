using Microsoft.Playwright;
using PlaywrightWithReqnroll.Driver;

namespace PlaywrightWithReqnroll.Pages;

/// <summary>
/// Represents the inventory page and provides methods to interact with and verify elements on the page.
/// </summary>
public class InventoryPage(IPlaywrightDriver playwrightDriver)
{
    /// <summary>
    /// Verifies that the shopping cart element is visible on the inventory page.
    /// </summary>
    /// <returns>A task that represents the asynchronous verification operation.</returns>
    public async Task VerifyShoppingCartIsVisibleAsync()
    {
        var page = await playwrightDriver.Page;

        var shoppingCart = page.Locator("#shopping_cart_container");

        await Assertions.Expect(shoppingCart).ToBeVisibleAsync();
    }
}