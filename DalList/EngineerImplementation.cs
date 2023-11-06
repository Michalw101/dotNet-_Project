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
        if (Read(id) == null)
        {
            throw new Exception($"Engineer with ID = {id} does not exist");
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
        Engineer? engineer = Read(item.Id);
        if (engineer == null)
        {
            throw new Exception($"Engineer with ID = {item.Id} does not exist");
        }
        Delete(item.Id);
        engineer = item;


        for (int i = 0; i < DataSourse.Engineers.Count; i++)
            if (DataSourse.Engineers[i].Id == item.Id)
            {
                if(DataSourse.Engineers[i]==null)
                    throw new Exception($"Engineer with ID = {item.Id} does not exist");
                DataSourse.Engineers[i]= engineer;
            }
    }
}
