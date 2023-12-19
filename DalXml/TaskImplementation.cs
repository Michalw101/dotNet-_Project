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
        int id = XMLTools.GetAndIncreaseNextId("data-config", "NextTaskId");
        List<Task> list = XMLTools.LoadListFromXMLSerializer<Task>("tasks");
        list.Add(item with { Id = id });
        XMLTools.SaveListToXMLSerializer<Task>(list, "tasks");
        return id;
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
            Task task = newTask with { IsActive = false };
            Update(task);
        }
    }

    public Task? Read(int id)
    {
        return XMLTools.LoadListFromXMLSerializer<Task>("tasks").FirstOrDefault(element => element.Id == id);
    }

    public Task? Read(Func<Task, bool> filter)
    {
        return XMLTools.LoadListFromXMLSerializer<Task>("tasks").FirstOrDefault(filter);
    }

    public IEnumerable<Task?> ReadAll(Func<Task, bool>? filter = null)
    {
        if (filter == null)
            return XMLTools.LoadListFromXMLSerializer<Task>("tasks").Select(item => item);
        else
            return XMLTools.LoadListFromXMLSerializer<Task>("tasks").Where(filter);
    }

    public void Update(Task item)
    {
        List<Task> list = XMLTools.LoadListFromXMLSerializer<Task>("tasks");

        Task? task = list.FirstOrDefault(element => element.Id == item.Id);
        if (task == null)
        {
            throw new DalDoesNotExistException($"task with ID = {item.Id} does not exist");
        }
        list.Remove(task);
        list.Add(item);
        XMLTools.SaveListToXMLSerializer<Task>(list, "tasks");
    }
}
