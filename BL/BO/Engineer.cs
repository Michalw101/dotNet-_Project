using DO;

namespace BO
{
    /// <summary>
    /// Represents an Engineer entity.
    /// </summary>
    public class Engineer
    {
        /// <summary>
        /// Gets or sets the ID of the Engineer.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Gets or sets the name of the Engineer.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the email of the Engineer.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets the experience level of the Engineer.
        /// </summary>
        public EngineerExperience Level { get; set; }

        /// <summary>
        /// Gets or sets the cost associated with the Engineer.
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Gets or sets the Task assigned to the Engineer.
        /// </summary>
        public Task? Task { get; set; } = null;

        /// <summary>
        /// Returns a string that represents the current Engineer object.
        /// </summary>
        /// <returns>A string representation of the Engineer.</returns>
        public override string ToString() => this.ToStringProperty();
    }
}
