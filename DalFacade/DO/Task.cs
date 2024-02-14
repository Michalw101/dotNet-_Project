namespace DO;


/// <summary>
/// Task entity represents a task with all its properties.
/// </summary>
/// <param name="Id">The unique identifier of the task.</param>
/// <param name="Alias">The alias of the task.</param>
/// <param name="Description">The description of the task.</param>
/// <param name="isMileStone">Indicates if the task is a milestone.</param>
/// <param name="CreatedAtDate">The date and time when the task was created.</param>
/// <param name="EngineerId">The ID of the engineer assigned to the task (optional).</param>
/// <param name="ComplexityLevel">The complexity level of the task (optional).</param>
/// <param name="RequiredEffortTime">The required effort time for the task (optional).</param>
/// <param name="StartDate">The start date of the task (optional).</param>
/// <param name="ScheduledDate">The scheduled date of the task (optional).</param>
/// <param name="DeadlineDate">The deadline date of the task (optional).</param>
/// <param name="Remarks">Remarks about the task (optional).</param>
/// <param name="CompleteDate">The completion date of the task (optional).</param>
/// <param name="Deliverables">The deliverables of the task (optional).</param>

public record Task
(
    int Id,
    string Alias,
    string Description,
    bool isMileStone,
    DateTime CreatedAtDate,
    int? EngineerId = null,
    EngineerExperience? ComplexityLevel = null,
    TimeSpan? RequiredEffortTime = null,
    DateTime? StartDate = null,
    DateTime? ScheduledDate = null,
    DateTime? DeadlineDate = null,
    string? Remarks = null,
    DateTime? CompleteDate = null,
    string? Deliverables = null
)
{
    public bool IsActive { get; set; } = true;

    public Task() : this(0, string.Empty, string.Empty, false, DateTime.MinValue, 0)
    {
    }
}


