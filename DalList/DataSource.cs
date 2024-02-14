namespace Dal;

/// <summary>
/// Provides access to the data sources for engineers, tasks, and dependencies.
/// </summary>

internal static class DataSource
{
    /// <summary>
    /// Gets the list of engineers.
    /// </summary>
    internal static List<DO.Engineer> Engineers { get; } = new();
   
    /// <summary>
    /// Gets the list of tasks.
    /// </summary>
    internal static List<DO.Task> Tasks { get; } = new();

    /// <summary>
    /// Gets the list of dependencies.
    /// </summary>
    internal static List<DO.Dependency> Dependencies { get; } = new();

    /// <summary>
    /// Provides configuration settings for generating unique IDs for tasks and dependencies.
    /// </summary>
    internal static class Config //run- indexes class for Task and Dependency
    {

        /// <summary>
        /// The starting ID for tasks.
        /// </summary>
        internal const int startTaskId = 0;
        private static int nextTaskId = startTaskId;

        /// <summary>
        /// Gets the next available task ID.
        /// </summary>
        internal static int NextTaskId { get => nextTaskId++; }


        /// <summary>
        /// The starting ID for dependencies.
        /// </summary>
        internal const int startDependencyId = 0;
        private static int nextDependencyId = startDependencyId;

        /// <summary>
        /// Gets the next available dependency ID.
        /// </summary>
        internal static int NextDependencyId { get => nextDependencyId++; }

    }

}
