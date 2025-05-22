using Npgsql;

namespace PlaywrightWithReqnroll.Database.Providers;

/// <summary>
/// Provides a base implementation for PostgreSQL database providers, managing connection creation and disposal.
/// </summary>
public abstract class BaseDbProvider(string connectionString) : IDisposable
{
    private NpgsqlConnection? _connection;

    /// <summary>
    /// Gets an open <see cref="NpgsqlConnection"/> instance.
    /// If the connection is not already open, it will be created and opened.
    /// </summary>
    protected NpgsqlConnection Connection
    {
        get
        {
            if (_connection == null)
            {
                _connection = new NpgsqlConnection(connectionString);
                _connection.Open();
            }
            return _connection;
        }
    }

    /// <summary>
    /// Disposes the underlying database connection and releases resources.
    /// </summary>
    public void Dispose()
    {
        _connection?.Dispose();
        _connection = null;
    }
}