namespace Dal;
using DalApi;
using DO;

/// <summary>
/// Provides implementation for managing engineers.
/// </summary>
internal class EngineerImplementation : IEngineer
{
    /// <summary>
    /// Creates a new engineer.
    /// </summary>
    /// <param name="item">The engineer to create.</param>
    /// <returns>The ID of the newly created engineer.</returns>
    public int Create(Engineer item)
    {
        List<Engineer> list = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        if (Read(item.Id) != null)
        {
            throw new DalAlreadyExistsException($"Student with ID={item.Id} already exists");
        }
        list.Add(item);
        XMLTools.SaveListToXMLSerializer<Engineer>(list,"engineers");
        return item.Id;
    }

    /// <summary>
    /// Deletes an engineer by ID.
    /// </summary>
    /// <param name="id">The ID of the engineer to delete.</param>
    public void Delete(int id)
    {
        List<Engineer> list = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        Engineer? newEngineer = list.FirstOrDefault(element => element.Id == id);
        if (newEngineer == null)
        {
            throw new DalDoesNotExistException($"Engineer with ID = {id} does not exist");
        }
        else if (XMLTools.LoadListFromXMLSerializer<Task>("task").FirstOrDefault(element => element.EngineerId == id) != null)
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
    public Engineer? Read(int id)
    {
        return XMLTools.LoadListFromXMLSerializer<Engineer>("engineers").FirstOrDefault(element => element.Id == id);
    }

    /// <summary>
    /// Reads an engineer based on the provided filter.
    /// </summary>
    /// <param name="filter">The filter condition to apply.</param>
    /// <returns>The first engineer that matches the filter condition.</returns>
    public Engineer? Read(Func<Engineer, bool> filter)
    {
        return XMLTools.LoadListFromXMLSerializer<Engineer>("engineers").FirstOrDefault(filter);
    }

    /// <summary>
    /// Reads all engineers based on the provided filter condition.
    /// </summary>
    /// <param name="filter">The filter condition to apply, or null to read all engineers.</param>
    /// <returns>An enumerable collection of engineers that match the filter condition.</returns>
    public IEnumerable<Engineer?> ReadAll(Func<Engineer, bool>? filter)
    {
        if (filter == null)
            return XMLTools.LoadListFromXMLSerializer<Engineer>("engineers").Select(item => item);
        else
            return XMLTools.LoadListFromXMLSerializer<Engineer>("engineers").Where(filter);
    }

    /// <summary>
    /// Updates an existing engineer.
    /// </summary>
    /// <param name="item">The engineer to update.</param>
    public void Update(Engineer item)
    {
        List<Engineer> list = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");

        Engineer? engineer = list.FirstOrDefault(element => element.Id == item.Id);
        if (engineer == null)
        {
            throw new DalDoesNotExistException($"Engineer with ID = {item.Id} does not exist");
        }
        list.Remove(engineer);
        list.Add(item);
        XMLTools.SaveListToXMLSerializer<Engineer>(list, "engineers");
    }
}
