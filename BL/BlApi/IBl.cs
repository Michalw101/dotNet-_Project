namespace BlApi;

/// <summary>
/// Represents the interface for the business logic layer.
/// </summary>
public interface IBl
{
    /// <summary>
    /// Gets the instance of the Engineer interface.
    /// </summary>
    public IEngineer Engineer { get; }

    /// <summary>
    /// Gets the instance of the Task interface.
    /// </summary>
    public ITask Task { get; }

    /// <summary>
    /// Gets the instance of the Milestone interface.
    /// </summary>
    public IMilestone Milestone { get; }
}

