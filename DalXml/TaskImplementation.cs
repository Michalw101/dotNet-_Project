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
        XElement? taskList = XMLTools.LoadListFromXMLElement("tasks");
        int id = XMLTools.GetAndIncreaseNextId("data-config", "NextTaskId");
        Task newTask = item with { Id = id };
        taskList.Add(newTask);
        XMLTools.SaveListToXMLElement(taskList, "tasks");
        return newTask.Id;
    }

    public void Delete(int id)
    {
        XElement taskList = XMLTools.LoadListFromXMLElement("tasks");
        XElement? taskElement = taskList.Elements("task").FirstOrDefault(task => (int)task?.Element("Id")! == id);
        if (taskElement == null)
        {
            throw new DalDoesNotExistException($"Task with ID = {id} does not exist");
        }
        else if (XMLTools.LoadListFromXMLElement("dependencies").Elements("dependency").FirstOrDefault(element => (int)element.Element("DependsOnTask")! == id) != null)
        {
            throw new DalDeletionImpossibleException($"Task with ID = {id} has dependent task and cannot be deleted");
        }

        Task task = newTask with { IsActive = false };
        Update(task);
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
