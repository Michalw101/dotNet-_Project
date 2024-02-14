namespace DO;

/// <summary>
/// Dependency entity represents a dependency between tasks.
/// </summary>
/// <param name="Id">The unique identifier of the dependency.</param>
/// <param name="DependentTask">The ID of the task that depends on another task.</param>
/// <param name="DependsOnTask">The ID of the task that is depended upon.</param>

public record Dependency
(
    int Id,
    int DependentTask,
    int DependsOnTask
);
