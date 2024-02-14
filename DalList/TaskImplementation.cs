namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Provides implementation for CRUD operations related to tasks.
/// </summary>
internal class TaskImplementation : ITask
{
    /// <summary>
    /// Creates a new task.
    /// </summary>
    /// <param name="item">The task to create.</param>
    /// <returns>The ID of the created task.</returns>
    public int Create(Task item) //Create Task
    {
        int id = DataSource.Config.NextTaskId;
        Task newTask=item with { Id = id };
        DataSource.Tasks.Add(newTask);
        return newTask.Id;
    }

    /// <summary>
    /// Deletes a task by ID.
    /// </summary>
    /// <param name="id">The ID of the task to delete.</param>
    public void Delete(int id) //Delete Task by id
    {
        Task? newTask = DataSource.Tasks.FirstOrDefault(element => element.Id == id);
        if (newTask == null)
        {
            throw new DalDoesNotExistException($"Task with ID = {id} does not exist");
        }
        else if (DataSource.Dependencies.FirstOrDefault(element => element.DependsOnTask == id) != null)
        {
            throw new DalDeletionImpossibleException($"Task with ID = {id} has dependent task and cannot be deleted");
        }
        Task task = newTask with { IsActive = false };
        Update(task);
    }

    /// <summary>
    /// Reads a task by ID.
    /// </summary>
    /// <param name="id">The ID of the task to read.</param>
    /// <returns>The task with the specified ID.</returns>
    public Task? Read(int id) //find Task by Id
    {
        return DataSource.Tasks.FirstOrDefault(element => element.Id == id);
    }

    /// <summary>
    /// Reads all tasks, optionally filtered by a condition.
    /// </summary>
    /// <param name="filter">An optional filter condition.</param>
    /// <returns>A collection of tasks.</returns>
    public IEnumerable<Task?> ReadAll(Func<Task, bool>? filter = null) //stage 2, return all the Tasks by given filter
    {
        if (filter == null)
            return DataSource.Tasks.Select(item => item);
        else
            return DataSource.Tasks.Where(filter);
    }

    /// <summary>
    /// Updates a task by ID.
    /// </summary>
    /// <param name="item">The task with updated information.</param>
    public void Update(Task item)//update Task by Id
    {
        Task? task = DataSource.Tasks.FirstOrDefault(element => element.Id == item.Id);
        if (task == null)
        {
            throw new DalDoesNotExistException($"Task with ID = {item.Id} does not exist");
        }
        DataSource.Tasks.Remove(task);
        DataSource.Tasks.Add(item);
    }

    /// <summary>
    /// Reads a task based on a filter condition.
    /// </summary>
    /// <param name="filter">The filter condition.</param>
    /// <returns>The task matching the filter condition.</returns>
    public Task? Read(Func<Task, bool> filter) // stage 2, find Task by filter
    {
        return DataSource.Tasks.FirstOrDefault(filter);
    }
}
