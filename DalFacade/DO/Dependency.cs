namespace DO;
/// <summary>
/// Dependency entity
/// </summary>
/// <param name="Id"></param>
/// <param name="DependentTask"></param>
/// <param name="DependsonTask"></param>
public record Dependency
(
    int Id
    int DependentTask
    int DependsonTask
)
