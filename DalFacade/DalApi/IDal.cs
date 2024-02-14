namespace DalApi;

// <summary>
/// Represents an interface for the Data Access Layer (DAL).
/// </summary>
public interface IDal
{
    /// <summary>
    /// Gets the engineer interface for accessing engineer-related data.
    /// </summary>
    IEngineer Engineer { get; }

    /// <summary>
    /// Gets the task interface for accessing task-related data.
    /// </summary>
    ITask Task { get; }

    /// <summary>
    /// Gets the dependency interface for accessing dependency-related data.
    /// </summary>
    IDependency Dependency { get; }

}
