namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

internal class DependencyImplementation : IDependency
{
    public int Create(Dependency item)
    {
        int id = DataSourse.Config.NextDependencyId;
        Dependency newDependency = item with { Id = id };
        DataSourse.Dependencies.Add(newDependency);
        return id;
    }

    public void Delete(int id)
    {
        Dependency? newDependency = DataSourse.Dependencies.FirstOrDefault(element => element.Id == id);

        if (newDependency == null)
            throw new Exception($"Dependecy with ID = {id} does not exist");
        DataSourse.Dependencies.Remove(newDependency);
    }

    public Dependency? Read(int id)
    {
        return DataSourse.Dependencies.FirstOrDefault(element => element.Id == id);
    }

    public List<Dependency?> ReadAll()
    {
        return new List<Dependency?>(DataSourse.Dependencies);
    }

    public void Update(Dependency item)
    {
        Dependency? dependency = DataSourse.Dependencies.FirstOrDefault(element => element.Id == item.Id);
        if (dependency == null)
        {
            throw new Exception($"Dependency with ID = {item.Id} does not exist");
        }
        DataSourse.Dependencies.Remove(dependency);
        DataSourse.Dependencies.Add(item);
    }
}
