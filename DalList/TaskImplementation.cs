namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;
using System.Linq;

internal class TaskImplementation : ITask
{
    public int Create(Task item) //Create Task
    {
        int id = DataSource.Config.NextTaskId;
        Task newTask=item with { Id = id };
        DataSource.Tasks.Add(newTask);
        return newTask.Id;
    }

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

    public Task? Read(int id) //find Task by Id
    {
        return DataSource.Tasks.FirstOrDefault(element => element.Id == id);
    }

    public IEnumerable<Task?> ReadAll(Func<Task, bool>? filter = null) //stage 2, return all the Tasks by given filter
    {
        if (filter == null)
            return DataSource.Tasks.Select(item => item);
        else
            return DataSource.Tasks.Where(filter);
    }


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

    public Task? Read(Func<Task, bool> filter) // stage 2, find Task by filter
    {
        return DataSource.Tasks.FirstOrDefault(filter);
    }
}
