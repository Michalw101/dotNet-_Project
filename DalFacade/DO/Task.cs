﻿namespace DO;
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
    int Id,
    string Description,
    DateTime CreatedAt,
    DateTime ForecastDate,
    DateTime Deadline,
    int EngineerId ,
    EngineerExperience ComplexityLevel,
    string? Alias = null,
    string? Remarks = null,
    bool MileStone = false,
    DateTime? Start = null,
    DateTime? Copmlete = null,
    string? Deliverables = null
)
{
    public bool IsActive { get; set; } = true;

    public Task() : this(0, string.Empty, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, 0, EngineerExperience.Junior)
    {
    }
}


