using DO;

namespace BO
{
    /// <summary>
    /// Represents a Milestone associated with a Task entity.
    /// </summary>
    public class MilestoneInTask
    {
        /// <summary>
        /// Gets or sets the ID of the Milestone within a Task.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Gets or sets the alias of the Milestone within a Task.
        /// </summary>
        public string Alias { get; set; }
    }
}
