namespace BlApi;

/// <summary>
/// Represents a factory class for creating instances of business logic classes.
/// </summary>
public static class Factory
{
    /// <summary>
    /// Gets an instance of the business logic implementation.
    /// </summary>
    /// <returns>An instance of the business logic implementation.</returns>
    public static IBl Get() => new BlImplementation.Bl();
}
