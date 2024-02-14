namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Provides implementation for CRUD operations related to engineers.
/// </summary>

internal class EngineerImplementation : IEngineer
{

    /// <summary>
    /// Creates a new engineer.
    /// </summary>
    /// <param name="item">The engineer to create.</param>
    /// <returns>The ID of the created engineer.</returns>

    public int Create(Engineer item)// Create Engineer
    {
        if (Read(item.Id) != null)
        {
            throw new DalAlreadyExistsException($"Student with ID={item.Id} already exists");
        }
        DataSource.Engineers.Add(item);
        return item.Id;
    }

    /// <summary>
    /// Deletes an engineer by ID.
    /// </summary>
    /// <param name="id">The ID of the engineer to delete.</param>

    public void Delete(int id) //Delete Engineer by Id
    {
        Engineer? newEngineer = DataSource.Engineers.FirstOrDefault(element => element.Id == id);

        if (newEngineer == null)
        {
            throw new DalDoesNotExistException($"Engineer with ID = {id} does not exist");
        }
        else if (DataSource.Tasks.FirstOrDefault(element => element.EngineerId == id) != null)
        {
            throw new DalDeletionImpossibleException($"Engineer with ID = {id} have tasks and canot be deleted");
        }
        else
        {
            Engineer engineer = newEngineer with { IsActive = false };
            Update(engineer);
        } 
    }

    /// <summary>
    /// Reads an engineer by ID.
    /// </summary>
    /// <param name="id">The ID of the engineer to read.</param>
    /// <returns>The engineer with the specified ID.</returns>

    public Engineer? Read(int id) //find Engineer by id
    {
        return DataSource.Engineers.FirstOrDefault(element => element.Id == id);
    }

    /// <summary>
    /// Reads all engineers, optionally filtered by a condition.
    /// </summary>
    /// <param name="filter">An optional filter condition.</param>
    /// <returns>A collection of engineers.</returns>

    public IEnumerable<Engineer?> ReadAll(Func<Engineer, bool>? filter = null) //stage 2, return all Engineers by filter
    {
        if (filter == null)
            return DataSource.Engineers.Select(item => item);
        else
            return DataSource.Engineers.Where(filter);
    }

    /// <summary>
    /// Updates an engineer by ID.
    /// </summary>

    public void Update(Engineer item) //update engineer by id
    {
        Engineer? engineer = DataSource.Engineers.FirstOrDefault(element=>element.Id == item.Id);
        if (engineer == null)
        {
            throw new DalDoesNotExistException($"Engineer with ID = {item.Id} does not exist");
        }
        DataSource.Engineers.Remove(engineer);
        DataSource.Engineers.Add(item);
    }

    /// <summary>
    /// Reads an engineer based on a filter condition.
    /// </summary>
    /// <param name="filter">The filter condition.</param>
    /// <returns>The engineer matching the filter condition.</returns>

    public Engineer? Read(Func<Engineer, bool> filter) // stage 2, find engineer by filter
    {
        return DataSource.Engineers.FirstOrDefault(filter);
    }
}

