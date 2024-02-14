namespace DO;
/// <summary>
/// Task entity
/// </summary>
/// <param name="Id">unique ID created automatically</param>
/// <param name="Description"></param>
/// <param name="Alias"></param>
/// <param name="isMileStone"></param>
/// <param name="CreatedAt"></param>
/// <param name="Start"></param>
/// <param name="ScheduledDate"></param>
/// <param name="ForecastDate"></param>
/// <param name="Deadline"></param>
/// <param name="Copmlete"></param>
/// <param name="Deliverables"></param>
/// <param name="Remarks"></param>
/// <param name="EngineerId"></param>
/// <param name="ComplexityLevel"></param>
/// 
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


