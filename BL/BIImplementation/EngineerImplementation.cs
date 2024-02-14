namespace BlImplementation;
using BlApi;
using DO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

/// <summary>
/// Implements the <see cref="IEngineer"/> interface for managing engineers.
/// </summary>
internal class EngineerImplementation : IEngineer
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    /// <summary>
    /// Creates a new engineer.
    /// </summary>
    /// <param name="item">The engineer object containing details of the new engineer.</param>
    /// <returns>The ID of the newly created engineer.</returns>
    /// <exception cref="BO.BlUnvalidException">Thrown when provided engineer data is invalid.</exception>
    /// <exception cref="BO.BlAlreadyExistsException">Thrown when an engineer with the same ID already exists.</exception>

    public int Create(BO.Engineer item)
    {
        if (item.Id <= 0)
            throw new BO.BlUnvalidException($"ID = {item.Id} is not valid");
        if (item.Name == null)
            throw new BO.BlUnvalidException($"Name = {item.Name} is not valid");
        if (item.Cost <= 0)
            throw new BO.BlUnvalidException($"Cost = {item.Cost} is not valid");
        if (new MailAddress(item.Email) == null)
            throw new BO.BlUnvalidException($"Email = {item.Cost} is not valid");
        DO.Engineer doEngineer = new DO.Engineer(item.Id, item.Name, item.Email, (DO.EngineerExperience)item.Level, item.Cost);
        try
        {
            int idEngineer = _dal.Engineer.Create(doEngineer);
            return idEngineer;
        }
        catch (DO.DalAlreadyExistsException ex)
        {
            throw new BO.BlAlreadyExistsException($"Engineer with ID={item.Id} already exists", ex);
        }
    }

    /// <summary>
    /// Deletes an engineer.
    /// </summary>
    /// <param name="id">The ID of the engineer to delete.</param>
    /// <exception cref="BO.BlDoesNotExistException">Thrown when the engineer with the specified ID does not exist.</exception>
    /// <exception cref="BO.BlDeletionImpossibleException">Thrown when deletion is not possible due to existing tasks associated with the engineer.</exception>

    public void Delete(int id)
    {
        DO.Engineer? doEngineer = _dal.Engineer.Read(id);
        if (doEngineer == null)
            throw new BO.BlDoesNotExistException($"Engineer with ID={id} does Not exist");
        if (
            (from DO.Task doTask in _dal.Task.ReadAll()
             select doTask).FirstOrDefault(element => element.EngineerId == id)
         != null)
            throw new BO.BlDeletionImpossibleException($"Engineer with ID = {id} have tasks and canot be deleted");
        try
        {
            _dal.Engineer.Delete(id);
        }
        catch (DalAlreadyExistsException ex)
        {
            throw new BO.BlDeletionImpossibleException($"Engineer with ID = {id} have canot be deleted", ex);
        }

    }

    /// <summary>
    /// Reads an engineer by ID.
    /// </summary>
    /// <param name="id">The ID of the engineer to read.</param>
    /// <returns>The engineer with the specified ID.</returns>
    /// <exception cref="BO.BlDoesNotExistException">Thrown when the engineer with the specified ID does not exist.</exception>

    public BO.Engineer? Read(int id)
    {
        DO.Engineer? doEngineer = _dal.Engineer.Read(id);
        if (doEngineer == null)
            throw new BO.BlDoesNotExistException($"Engineer with ID={id} does Not exist");
        return new BO.Engineer()
        {
            Id = id,
            Name = doEngineer.Name,
            Email = doEngineer.Email,
            Level = (BO.EngineerExperience)Convert.ToInt32(doEngineer.Level),
            Cost = doEngineer.Cost
        };

    }

    /// <summary>
    /// Reads all engineers, optionally filtered by a condition.
    /// </summary>
    /// <param name="filter">Optional filter condition.</param>
    /// <returns>An enumerable collection of engineers.</returns>

    public IEnumerable<BO.Engineer?> ReadAll(Func<BO.Engineer, bool>? filter = null)
    {
        IEnumerable<BO.Engineer?> query = from DO.Engineer doEngineer in _dal.Engineer.ReadAll()
                                          select new BO.Engineer
                                          {
                                              Id = doEngineer!.Id,
                                              Name = doEngineer.Name,
                                              Email = doEngineer.Email,
                                              Level = (BO.EngineerExperience)doEngineer.Level,
                                              Cost = doEngineer.Cost,
                                              Task = null
                                          };

        if (filter != null)
        {
            query = query.Where(e => filter(e!));
        }

        return query;
    }

    /// <summary>
    /// Updates an existing engineer.
    /// </summary>
    /// <param name="item">The updated engineer object.</param>
    /// <exception cref="BO.BlDoesNotExistException">Thrown when the engineer with the specified ID does not exist.</exception>

    public void Update(BO.Engineer item)
    {
        DO.Engineer? doEngineer = new DO.Engineer(
            item.Id,
            item.Name,
            item.Email,
            (DO.EngineerExperience)item.Level,
            item.Cost);
        try
        {
            _dal.Engineer.Update(doEngineer);
        }
        catch (DalDoesNotExistException ex)
        {
            throw new BO.BlDoesNotExistException($"Engineer with ID = {item.Id} does not exist", ex);

        }
    }
}