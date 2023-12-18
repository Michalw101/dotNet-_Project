namespace Dal;
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

internal class TaskImplementation : ITask
{
    public int Create(Task item)
    {
        List<Task> list = XMLTools.LoadListFromXMLSerializer<Task>("tasks");
        if (Read(item.Id) != null)
        {
            throw new DalAlreadyExistsException($"Task with ID={item.Id} already exists");
        }
        list.Add(item);
        XMLTools.SaveListToXMLSerializer<Task>(list, "tasks");
        return item.Id;
    }

    public void Delete(int id)
    {
        List<Task> list = XMLTools.LoadListFromXMLSerializer<Task>("tasks");
        Task? newTask = list.FirstOrDefault(element => element.Id == id);
        if (newTask == null)
        {
            throw new DalDoesNotExistException($"Task with ID = {id} does not exist");
        }
        else if (XMLTools.LoadListFromXMLSerializer<Dependency>("dependencies").FirstOrDefault(element => element.DependsOnTask == id) != null)
        {
            throw new DalDeletionImpossibleException($"Task with ID = {id} has dependent task and cannot be deleted");
        }
        else
        {
            Engineer engineer = newEngineer with { IsActive = false };
            Update(engineer);
        }
    }

    public Task? Read(int id)
    {
        return XMLTools.LoadListFromXMLElement("tasks").Elements("task").FirstOrDefault(element => (int)element.Element("Id") == id);
    }

    public Task? Read(Func<Task, bool> filter)
    {
        return XMLTools.LoadListFromXMLElement("tasks").Descendants("task").FirstOrDefault(filter);
    }

    public IEnumerable<Task?> ReadAll(Func<Task, bool>? filter = null)
    {
        throw new NotImplementedException();
    }

    public void Update(Task item)
    {
        throw new NotImplementedException();
    }
}
