namespace DO;
/// <summary>
/// Engineer entity represent engineer with all its props.
/// </summary>
/// <param name="Id">required, personal unique id</param>
/// <param name="Name">private name</param>
/// <param name="MailAddress">mail address</param>
/// <param name="Level">engineer experience</param>
/// <param name="Cost">salary for hour</param>
public record Engineer
(
    int Id,
    string Name,
    string Email,
    EngineerExperience Level,
    double? Cost = null
)
{
    public bool IsActive { get; set; } = true;

    public Engineer() : this(0, string.Empty, string.Empty, EngineerExperience.Junior, null)
    {

    }
}
