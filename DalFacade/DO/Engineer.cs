namespace DO;

/// <summary>
/// Engineer entity represents an engineer with all its properties.
/// </summary>
/// <param name="Id">The unique identifier of the engineer.</param>
/// <param name="Name">The name of the engineer.</param>
/// <param name="Email">The email address of the engineer.</param>
/// <param name="Level">The experience level of the engineer.</param>
/// <param name="Cost">The salary for the engineer per hour.</param>

public record Engineer
(
    int Id,
    string Name,
    string Email,
    EngineerExperience Level,
    double Cost 
)
{
    /// <summary>
    /// Indicates whether the engineer is active.
    /// </summary>

    public bool IsActive { get; set; } = true;


    /// <summary>
    /// Default constructor for the Engineer class.
    /// </summary>

    public Engineer() : this(0, string.Empty, string.Empty, EngineerExperience.Beginner, 0)
    {

    }
}
