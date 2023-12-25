using DO;
namespace BO;

public class Task
{
    public int Id { get; init; }
    public string Description { get; set;}
    public 
    public EngineerExperience Level { get; set; }
    public double Cost { get; set; }
    public string? Alias { get; set; } = null;
    public Task? task { get; set; } = null;
}
