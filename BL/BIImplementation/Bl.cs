namespace BlImplementation;
using BlApi;

/// <summary>
/// Represents the business logic implementation class.
/// </summary>
internal class Bl : IBl
{
    /// <summary>
    /// Gets the instance of the Engineer implementation.
    /// </summary>
    public IEngineer Engineer => new EngineerImplementation();

    /// <summary>
    /// Gets the instance of the Task implementation.
    /// </summary>
    public ITask Task => new TaskImplementation();

    /// <summary>
    /// Gets the instance of the Milestone implementation.
    /// </summary>
    public IMilestone Milestone => new MilestoneImplementation();
}

