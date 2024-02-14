using DO;

namespace BO
{
    /// <summary>
    /// Represents a task in the business logic layer.
    /// </summary>
    public class Task
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
        /// Gets or sets the date when the task was created.
        /// </summary>
        public DateTime CreatedAtDate { get; init; }

        /// <summary>
        /// Gets or sets the status of the task.
        /// </summary>
        public Status? Status { get; set; } = null;

        /// <summary>
        /// Gets or sets the milestone associated with the task.
        /// </summary>
        public MilestoneInTask? Milestone { get; set; } = null;

        /// <summary>
        /// Gets or sets the list of dependencies for the task.
        /// </summary>
        public List<TaskInList>? Dependencies { get; set; } = null;

        /// <summary>
        /// Gets or sets the complexity level of the task.
        /// </summary>
        public EngineerExperience? ComplexityLevel { get; set; } = null;

        /// <summary>
        /// Gets or sets the baseline start date of the task.
        /// </summary>
        public DateTime? BaselineStartDate { get; set; } = null;

        /// <summary>
        /// Gets or sets the start date of the task.
        /// </summary>
        public DateTime? StartDate { get; set; } = null;

        /// <summary>
        /// Gets or sets the scheduled start date of the task.
        /// </summary>
        public DateTime? ScheduledStartDate { get; set; } = null;

        /// <summary>
        /// Gets or sets the forecast date of the task.
        /// </summary>
        public DateTime? ForecastDate { get; set; } = null;

        /// <summary>
        /// Gets or sets the deadline date of the task.
        /// </summary>
        public DateTime? DeadlineDate { get; set; } = null;

        /// <summary>
        /// Gets or sets the complete date of the task.
        /// </summary>
        public DateTime? CompleteDate { get; set; } = null;

        /// <summary>
        /// Gets or sets the deliverables associated with the task.
        /// </summary>
        public string? Deliverables { get; set; } = null;

        /// <summary>
        /// Gets or sets any remarks associated with the task.
        /// </summary>
        public string? Remarks { get; set; } = null;

        /// <summary>
        /// Gets or sets the engineer assigned to the task.
        /// </summary>
        public Engineer? Engineer { get; set; } = null;

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() => this.ToStringProperty();
    }
}
