using DO;
namespace BO;

public class Milestone
{
    public int Id { get; init; }
    public required string Description { get; set; }
    public required string Alias { get; set; } 
    public DateTime CreatedAtDate { get; init; }
    public DateTime? ForecastDate { get; set; } = null;
    public DateTime? DeadlineDate { get; set; } = null;
    public DateTime? CompleteDate { get; set; } = null;
    public string? remarks { get; set; } = null;
    public Status? Status { get; set; } = null;
    public double? completionPercentage { get; set; } = null;
    public TaskInList? Dependencies { get; set; }= null;
}
