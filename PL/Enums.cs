using System.Collections;
namespace PL;
/// <summary>
/// Represents a collection of engineer experience levels.
/// </summary>
internal class EngineerExperienceCollection : IEnumerable
{
    static readonly IEnumerable<BO.EngineerExperience> s_enums =
(Enum.GetValues(typeof(BO.EngineerExperience)) as IEnumerable<BO.EngineerExperience>)!;

    /// <summary>
    /// Returns an enumerator that iterates through the engineer experience levels.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the engineer experience levels.</returns>
    public IEnumerator GetEnumerator() => s_enums.GetEnumerator();
}

