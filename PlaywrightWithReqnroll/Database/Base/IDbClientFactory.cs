/// <summary>
/// Defines a factory interface for creating and managing database connection instances.
/// </summary>
/// <typeparam name="T">The type of the database connection client.</typeparam>
public interface IDbProvider<T> : IDisposable
    where T : class
{
    /// <summary>
    /// Creates a new instance of the database connection client using the specified connection string.
    /// </summary>
    /// <param name="connectionString">The connection string to use for the database connection.</param>
    /// <returns>An instance of <typeparamref name="T"/> representing the database connection client.</returns>
    T CreateConnection(string connectionString);
}