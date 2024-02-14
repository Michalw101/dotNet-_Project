using DO;
namespace BO;

/// <summary>
/// Represents a milestone in a list.
/// </summary>
public class MilestoneInList
{
    /// <summary>
    /// Gets or sets the ID of the milestone.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Gets or sets the description of the milestone.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Gets or sets the alias of the milestone.
    /// </summary>
    public required string Alias { get; set; }

    /// <summary>
    /// Gets or sets the status of the milestone. Can be null.
    /// </summary>
    public Status? Status { get; set; } = null;

    /// <summary>
    /// Gets or sets the completion percentage of the milestone. Can be null.
    /// </summary>
    public double? CompletionPercentage { get; set; } = null;
}
