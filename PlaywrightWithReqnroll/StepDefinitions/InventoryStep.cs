using PlaywrightWithReqnroll.Pages;
using Reqnroll;

namespace PlaywrightWithReqnroll.StepDefinitions;

[Binding]
public class InventoryStep(InventoryPage inventoryPage)
{
    private readonly InventoryPage _inventoryPage = inventoryPage;

    [Then("I should be logged in successfully")]
    public async Task ThenIShouldBeLoggedInSuccessfully()
    {
        await _inventoryPage.VerifyShoppingCartIsVisibleAsync();
    }
}
