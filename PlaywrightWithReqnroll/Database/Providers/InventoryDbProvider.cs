using Dapper;
using PlaywrightWithReqnroll.Configuration;
using PlaywrightWithReqnroll.Models;

namespace PlaywrightWithReqnroll.Database.Providers;

/// <summary>
/// Provides database operations for the Inventory database.
/// </summary>
public class InventoryDbProvider(TestSettings testSettings)
    : BaseDbProvider(testSettings.ConnectionStrings.InventoryDb)
{
    /// <summary>
    /// Asynchronously retrieves the first <see cref="LoginCredentials"/> record from the Inventory table.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the first <see cref="LoginCredentials"/> found, or <c>null</c> if no record exists.
    /// </returns>
    public async Task<LoginCredentials?> GetInventoryAsync()
    {
        var result = await Connection.QueryAsync<LoginCredentials>(
            "SELECT * FROM Inventory");
        return result.FirstOrDefault();
    }
}