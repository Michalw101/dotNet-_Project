namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;
using System.Linq;

internal class EngineerImplementation : IEngineer
{
    public int Create(Engineer item)
    {
        if (Read(item.Id) != null)
        {
            throw new DalAlreadyExistsException($"Student with ID={item.Id} already exists");
        }
        DataSource.Engineers.Add(item);
        return item.Id;
    }

    public void Delete(int id)
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

    public Engineer? Read(int id)
    {
        return DataSource.Engineers.FirstOrDefault(element => element.Id == id);
    }

    public IEnumerable<Engineer?> ReadAll(Func<Engineer?, bool> filter = null) //stage 2
    {
        if (filter == null)
            return DataSource.Engineers.Select(item => item);
        else
            return DataSource.Engineers.Where(filter);
    }


    public void Update(Engineer item)
    {
        Engineer? engineer = DataSource.Engineers.FirstOrDefault(element=>element.Id == item.Id);
        if (engineer == null)
        {
            throw new DalDoesNotExistException($"Engineer with ID = {item.Id} does not exist");
        }
        DataSource.Engineers.Remove(engineer);
        DataSource.Engineers.Add(item);
    }

    public Engineer? Read(Func<Engineer, bool> filter) // stage 2
    {
        return DataSource.Engineers.FirstOrDefault(filter);
    }
}

