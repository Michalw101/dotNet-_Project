namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

internal class TaskImplementation : ITask
{
    public int Create(Task item)
    {
        int id = DataSource.Config.NextTaskId;
        Task newTask=item with { Id = id };
        DataSource.Tasks.Add(newTask);
        return newTask.Id;
    }

    public void Delete(int id)
    {
        Task? newTask = DataSource.Tasks.FirstOrDefault(element => element.Id == id);

        if (newTask == null)
        {
            throw new Exception($"Task with ID = {id} does not exist");
        }
        else if (DataSource.Dependencies.FirstOrDefault(element => element.DependsOnTask == id) != null)
        {
            throw new Exception($"Task with ID = {id} has dependent task and cannot be deleted");
        }
        DataSource.Tasks.Remove(newTask);
    }

    public Task? Read(int id)
    {
        return DataSource.Tasks.FirstOrDefault(element => element.Id == id);
    }

    public IEnumerable<Task?> ReadAll(Func<Task?, bool>? filter = null) //stage 2
    {
        if (filter == null)
            return DataSource.Tasks.Select(item => item);
        else
            return DataSource.Tasks.Where(filter);
    }

    public void Update(Task item)
    {
        Task? task = DataSource.Tasks.FirstOrDefault(element => element.Id == item.Id);
        if (task == null)
        {
            throw new Exception($"Task with ID = {item.Id} does not exist");
        }
        DataSource.Tasks.Remove(task);
        DataSource.Tasks.Add(item);
    }
}
