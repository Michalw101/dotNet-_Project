namespace BlApi;

/// <summary>
/// Represents the interface for operations related to Engineers.
/// </summary>
public interface IEngineer
{
    /// <summary>
    /// Creates a new Engineer.
    /// </summary>
    /// <param name="item">The Engineer object to create.</param>
    /// <returns>The ID of the newly created Engineer.</returns>
    public int Create(BO.Engineer item);

    /// <summary>
    /// Reads an Engineer with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the Engineer to read.</param>
    /// <returns>The Engineer object if found, null otherwise.</returns>
    public BO.Engineer? Read(int id);

    /// <summary>
    /// Reads all Engineers based on the provided filter.
    /// </summary>
    /// <param name="filter">The filter function to apply on Engineers (optional).</param>
    /// <returns>A collection of Engineer objects that match the filter.</returns>
    IEnumerable<BO.Engineer?> ReadAll(Func<BO.Engineer, bool>? filter = null);

    /// <summary>
    /// Updates an existing Engineer.
    /// </summary>
    /// <param name="item">The Engineer object to update.</param>
    public void Update(BO.Engineer item);

    /// <summary>
    /// Deletes an Engineer with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the Engineer to delete.</param>
    public void Delete(int id);
}

