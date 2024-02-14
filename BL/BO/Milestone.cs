using DO;

namespace BO
{
    /// <summary>
    /// Represents a Milestone entity.
    /// </summary>
    public class Milestone
    {
        /// <summary>
        /// Gets or sets the ID of the Milestone.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Gets or sets the description of the Milestone.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the alias of the Milestone.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the Milestone.
        /// </summary>
        public DateTime CreatedAtDate { get; init; }

        /// <summary>
        /// Gets or sets the forecast date of the Milestone.
        /// </summary>
        public DateTime? ForecastDate { get; set; } = null;

        /// <summary>
        /// Gets or sets the deadline date of the Milestone.
        /// </summary>
        public DateTime? DeadlineDate { get; set; } = null;

        /// <summary>
        /// Gets or sets the completion date of the Milestone.
        /// </summary>
        public DateTime? CompleteDate { get; set; } = null;

        /// <summary>
        /// Gets or sets any remarks related to the Milestone.
        /// </summary>
        public string? remarks { get; set; } = null;

        /// <summary>
        /// Gets or sets the status of the Milestone.
        /// </summary>
        public Status? Status { get; set; } = null;

        /// <summary>
        /// Gets or sets the completion percentage of the Milestone.
        /// </summary>
        public double? completionPercentage { get; set; } = null;

        /// <summary>
        /// Gets or sets the dependencies of the Milestone.
        /// </summary>
        public TaskInList? Dependencies { get; set; } = null;
    }
}
