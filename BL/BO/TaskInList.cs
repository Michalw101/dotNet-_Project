using DO;

namespace BO
{
    /// <summary>
    /// Represents a task in a list in the business logic layer.
    /// </summary>
    public class TaskInList
    {
        /// <summary>
        /// Gets or sets the ID of the task.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Gets or sets the description of the task.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the alias of the task.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the status of the task.
        /// </summary>
        public Status? Status { get; set; } = null;

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() => this.ToStringProperty();
    }
}
