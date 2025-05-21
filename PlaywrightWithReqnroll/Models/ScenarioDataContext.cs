namespace PlaywrightWithReqnroll.Models;

/// <summary>
/// Provides a context for sharing scenario-specific data between step definitions.
/// </summary>
public class ScenarioDataContext
{
    /// <summary>
    /// Gets or sets the login credentials used during the scenario.
    /// </summary>
    public LoginCredentials? LoginCredentials { get; set; }
}