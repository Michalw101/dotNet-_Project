namespace DO;
/// <summary>
/// Task entity
/// </summary>
/// <param name="Id">unique ID created automatically</param>
/// <param name="Description"></param>
/// <param name="Alias"></param>
/// <param name="MileStone"></param>
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
public record Task
(
    int Id
    string Description
    string? Alias
    bool MileStone = false
    datetime CreatedAt
    datetime? Start = null
    datetime ScheduledDate
    datetime? ForecastDate = null
    datetime? Deadline = null
    datetime? Copmlete = null
    string? Deliverables = null
    string? Remarks = null
    int EngineerId
    EngineerExperience ComplexityLevel
)