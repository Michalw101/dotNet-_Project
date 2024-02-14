using DO;

namespace BO
{
    /// <summary>
    /// Represents a task assigned to an engineer in the business logic layer.
    /// </summary>
    public class TaskInEngineer
    {
        /// <summary>
        /// Gets or sets the ID of the task.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Gets or sets the alias of the task.
        /// </summary>
        public required string Alias { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() => this.ToStringProperty();
    }
}
