namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Provides implementation for CRUD operations related to dependencies.
/// </summary>

internal class DependencyImplementation : IDependency
{

    /// <summary>
    /// Creates a new dependency.
    /// </summary>
    /// <param name="item">The dependency to create.</param>
    /// <returns>The ID of the created dependency.</returns>

    public int Create(Dependency item) //Create Dependency
    {
        int id = DataSource.Config.NextDependencyId;
        Dependency newDependency = item with { Id = id };
        DataSource.Dependencies.Add(newDependency);
        return newDependency.Id;
    }

    /// <summary>
    /// Deletes a dependency by ID.
    /// </summary>
    /// <param name="id">The ID of the dependency to delete.</param>

    public void Delete(int id) //Delete Dependency
    {
        Dependency? newDependency = DataSource.Dependencies.FirstOrDefault(element => element.Id == id);

        if (newDependency == null)
            throw new DalDoesNotExistException($"Dependecy with ID = {id} does not exist");
        DataSource.Dependencies.Remove(newDependency);
    }

    /// <summary>
    /// Finds a dependency by ID.
    /// </summary>
    /// <param name="id">The ID of the dependency to find.</param>
    /// <returns>The dependency with the specified ID.</returns>

    public Dependency? Read(int id) //Find Dependency by Id
    {
        return DataSource.Dependencies.FirstOrDefault(element => element.Id == id);
    }

    /// <summary>
    /// Reads all dependencies, optionally filtered by a condition.
    /// </summary>
    /// <param name="filter">An optional filter condition.</param>
    /// <returns>A collection of dependencies.</returns>

    public IEnumerable<Dependency?> ReadAll(Func<Dependency, bool>? filter = null) //stage 2, return all the Dependencies by given filter
    {
        if (filter == null)
            return DataSource.Dependencies.Select(item => item);
        else
            return DataSource.Dependencies.Where(filter);
    }

    /// <summary>
    /// Updates a dependency by ID.
    /// </summary>
    /// <param name="item">The dependency with updated information.</param>

    public void Update(Dependency item) //update Dependency by Id
    {
        Dependency? dependency = DataSource.Dependencies.FirstOrDefault(element => element.Id == item.Id);
        if (dependency == null)
        {
            throw new DalDoesNotExistException($"Dependency with ID = {item.Id} does not exist");
        }
        DataSource.Dependencies.Remove(dependency);
        DataSource.Dependencies.Add(item);
    }

    /// <summary>
    /// Finds a dependency based on a filter condition.
    /// </summary>
    /// <param name="filter">The filter condition.</param>
    /// <returns>The dependency matching the filter condition.</returns>

    public Dependency? Read(Func<Dependency, bool> filter) // stage 2, find Dependency by filter
    {
        return DataSource.Dependencies.FirstOrDefault(filter);
    }
}
    

