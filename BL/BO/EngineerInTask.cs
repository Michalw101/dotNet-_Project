using DO;

namespace BO
{
    /// <summary>
    /// Represents an Engineer assigned to a Task entity.
    /// </summary>
    public class EngineerInTask
    {
        /// <summary>
        /// Gets or sets the ID of the Engineer assigned to the Task.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Gets or sets the name of the Engineer assigned to the Task.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Returns a string that represents the current Engineer object.
        /// </summary>
        /// <returns>A string representation of the Engineer.</returns>
        public override string ToString() => this.ToStringProperty();
    }
}
