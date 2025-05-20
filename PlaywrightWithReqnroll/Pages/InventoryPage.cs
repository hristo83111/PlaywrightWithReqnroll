using Microsoft.Playwright;

namespace PlaywrightWithReqnroll.Pages;

public class InventoryPage(IPage page)
{
    private readonly IPage _page = page;
    private ILocator _shoppingCart => _page.Locator("#shopping_cart_container");
    public async Task VerifyShoppingCartIsVisibleAsync()
    {
        await Assertions.Expect(_shoppingCart).ToBeVisibleAsync();
    }
}

