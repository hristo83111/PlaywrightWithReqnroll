using NUnit.Framework;
using PlaywrightWithReqnroll.Models;
using PlaywrightWithReqnroll.Pages;
using Reqnroll;

namespace PlaywrightWithReqnroll.StepDefinitions;

[Binding]
public class InventoryStep(ScenarioDataContext scenarioDataContext, InventoryPage inventoryPage)
{
    const string expectUsername = "standard_user";

    [Then("I should be logged in successfully")]
    public async Task ThenIShouldBeLoggedInSuccessfully()
    {
        Assert.That(scenarioDataContext.LoginCredentials?.Username, Is.EqualTo(expectUsername));
        await inventoryPage.VerifyShoppingCartIsVisibleAsync();
    }
}
