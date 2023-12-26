using DO;

namespace BO;

public class Engineer
{
    public int Id { get; init; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public EngineerExperience Level { get; init; }
    public double Cost { get; set; }
    public Task? task { get; set; } = null;
}
