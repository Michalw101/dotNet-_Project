namespace Dal;
using DalApi;
using DO;

internal class EngineerImplementation : IEngineer
{
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

    public Engineer? Read(int id)
    {
        return XMLTools.LoadListFromXMLSerializer<Engineer>("engineers").FirstOrDefault(element => element.Id == id);
    }

    public Engineer? Read(Func<Engineer, bool> filter)
    {
        return XMLTools.LoadListFromXMLSerializer<Engineer>("engineers").FirstOrDefault(filter);
    }

    public IEnumerable<Engineer?> ReadAll(Func<Engineer, bool>? filter)
    {
        if (filter == null)
            return XMLTools.LoadListFromXMLSerializer<Engineer>("engineers").Select(item => item);
        else
            return XMLTools.LoadListFromXMLSerializer<Engineer>("engineers").Where(filter);
    }

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
