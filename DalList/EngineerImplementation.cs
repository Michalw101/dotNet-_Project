namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

public class EngineerImplementation : IEngineer
{
    public int Create(Engineer item)
    {
        if (Read(item.Id) != null)
        {
            throw new Exception($"Engineer with ID = {item.Id} already exist");
        }
        return item.Id;
    }

    public void Delete(int id)
    {
        Engineer? newEngineer = DataSourse.Engineers.Find(element => element.Id == id);

        if (newEngineer == null)
        {
            throw new Exception($"Engineer with ID = {id} does not exist");
        }
        else if (DataSourse.Tasks.Find(element => element.EngineerId == id) != null)
        {
            throw new Exception($"Engineer with ID = {id} have tasks and canot be deleted");
        }
        else
        {
            Engineer engineer = newEngineer with { isActive = false };
            Update(engineer);
        } 
    }

    public Engineer? Read(int id)
    {
        for (int i = 0; i < DataSourse.Engineers.Count; i++)
            if (DataSourse.Engineers[i].Id == id)
                return DataSourse.Engineers[i];
        return null;
    }

    public List<Engineer> ReadAll()
    {
        return new List<Engineer>(DataSourse.Engineers);
    }

    public void Update(Engineer item)
    {
        Engineer? engineer = DataSourse.Engineers.Find(element=>element.Id == item.Id);
        if (engineer == null)
        {
            throw new Exception($"Engineer with ID = {item.Id} does not exist");
        }
        DataSourse.Engineers.Remove(engineer);
        DataSourse.Engineers.Add(item);
    }
}
