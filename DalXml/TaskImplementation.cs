namespace Dal;
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

/// <summary>
/// Implementation of the <see cref="ITask"/> interface.
/// </summary>
internal class TaskImplementation : ITask
{
    /// <summary>
    /// Creates a new task.
    /// </summary>
    /// <param name="item">The task to create.</param>
    /// <returns>The ID of the newly created task.</returns>
    public int Create(Task item)
    {
        int id = XMLTools.GetAndIncreaseNextId("data-config", "NextTaskId");
        List<Task> list = XMLTools.LoadListFromXMLSerializer<Task>("tasks");
        list.Add(item with { Id = id });
        XMLTools.SaveListToXMLSerializer<Task>(list, "tasks");
        return id;
    }

    /// <summary>
    /// Deletes a task by ID.
    /// </summary>
    /// <param name="id">The ID of the task to delete.</param>
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

    /// <summary>
    /// Reads a task by ID.
    /// </summary>
    /// <param name="id">The ID of the task to read.</param>
    /// <returns>The task with the specified ID.</returns>
    public Task? Read(int id)
    {
        return XMLTools.LoadListFromXMLSerializer<Task>("tasks").FirstOrDefault(element => element.Id == id);
    }

    /// <summary>
    /// Reads a task based on a filter.
    /// </summary>
    /// <param name="filter">The filter to apply when reading the task.</param>
    /// <returns>The task that matches the filter.</returns>
    public Task? Read(Func<Task, bool> filter)
    {
        return XMLTools.LoadListFromXMLSerializer<Task>("tasks").FirstOrDefault(filter);
    }

    /// <summary>
    /// Reads all tasks based on an optional filter.
    /// </summary>
    /// <param name="filter">The optional filter to apply when reading tasks.</param>
    /// <returns>An enumerable collection of tasks.</returns>
    public IEnumerable<Task?> ReadAll(Func<Task, bool>? filter = null)
    {
        if (filter == null)
            return XMLTools.LoadListFromXMLSerializer<Task>("tasks").Select(item => item);
        else
            return XMLTools.LoadListFromXMLSerializer<Task>("tasks").Where(filter);
    }

    /// <summary>
    /// Updates an existing task.
    /// </summary>
    /// <param name="item">The task to update.</param>
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
