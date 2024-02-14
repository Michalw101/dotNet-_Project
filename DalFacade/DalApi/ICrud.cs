namespace DalApi;
using DO;

/// <summary>
/// Represents a generic interface for CRUD (Create, Read, Update, Delete) operations on entity objects.
/// </summary>
/// <typeparam name="T">The type of entity object.</typeparam>
public interface ICrud<T> where T : class
{

    /// <summary>
    /// Creates a new entity object in the DAL (Data Access Layer).
    /// </summary>
    /// <param name="item">The entity object to create.</param>
    /// <returns>The ID of the newly created entity object.</returns>
    int Create(T item); 

    /// <summary>
    /// Reads an entity object by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity object to read.</param>
    /// <returns>The entity object if found; otherwise, null.</returns>

    T? Read(int id);

    /// <summary>
    /// Reads all entity objects optionally filtered by a provided condition.
    /// </summary>
    /// <param name="filter">An optional filter condition.</param>
    /// <returns>A collection of entity objects.</returns>

    IEnumerable<T?> ReadAll(Func<T, bool>? filter = null);//stage 2

    /// <summary>
    /// Updates an entity object.
    /// </summary>
    /// <param name="item">The entity object to update.</param>

    void Update(T item); //Updates entity object

    /// <summary>
    /// Deletes an entity object by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity object to delete.</param>

    void Delete(int id); //Deletes an object by is Id

    /// <summary>
    /// Reads an entity object based on a provided filter condition.
    /// </summary>
    /// <param name="filter">The filter condition to apply.</param>
    /// <returns>The entity object if found; otherwise, null.</returns>

    T? Read(Func<T, bool> filter); // stage 2
}
