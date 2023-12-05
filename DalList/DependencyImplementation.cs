namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;
using System.Linq;

internal class DependencyImplementation : IDependency
{
    public int Create(Dependency item) //Create Dependency

    {
        int id = DataSource.Config.NextDependencyId;
        Dependency newDependency = item with { Id = id };
        DataSource.Dependencies.Add(newDependency);
        return newDependency.Id;
    }

    public void Delete(int id) //Delete Dependency
    {
        Dependency? newDependency = DataSource.Dependencies.FirstOrDefault(element => element.Id == id);

        if (newDependency == null)
            throw new DalDoesNotExistException($"Dependecy with ID = {id} does not exist");
        DataSource.Dependencies.Remove(newDependency);
    }
    public Dependency? Read(int id) //Find Dependency by Id
    {
        return DataSource.Dependencies.FirstOrDefault(element => element.Id == id);
    }

    public IEnumerable<Dependency?> ReadAll(Func<Dependency, bool>? filter = null) //stage 2, return all the Dependencies by given filter
    {
        if (filter == null)
            return DataSource.Dependencies.Select(item => item);
        else
            return DataSource.Dependencies.Where(filter);
    }

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

    public Dependency? Read(Func<Dependency, bool> filter) // stage 2, find Dependency by filter
    {
        return DataSource.Dependencies.FirstOrDefault(filter);
    }
}
    

