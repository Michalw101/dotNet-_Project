namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

internal class TaskImplementation : ITask
{
    public int Create(Task item)
    {
        int id = DataSourse.Config.NextTaskId;
        Task newTask=item with { Id = id };
        DataSourse.Tasks.Add(newTask);
        return newTask.Id;
    }

    public void Delete(int id)
    {
        Task? newTask = DataSourse.Tasks.Find(element => element.Id == id);

        if (newTask == null)
        {
            throw new Exception($"Task with ID = {id} does not exist");
        }
        else if (DataSourse.Dependencies.Find(element => element.DependsOnTask == id) != null)
        {
            throw new Exception($"Task with ID = {id} has dependent task and cannot be deleted");
        }
        DataSourse.Tasks.Remove(newTask);
    }

    public Task? Read(int id)
    {
        for (int i = 0; i < DataSourse.Tasks.Count; i++)
            if (DataSourse.Tasks[i].Id == id)
                return DataSourse.Tasks[i];
        return null;
    }

    public List<Task?> ReadAll()
    {
        return new List<Task?>(DataSourse.Tasks);
    }

    public void Update(Task item)
    {
        Task? task = DataSourse.Tasks.Find(element => element.Id == item.Id);
        if (task == null)
        {
            throw new Exception($"Task with ID = {item.Id} does not exist");
        }
        DataSourse.Tasks.Remove(task);
        DataSourse.Tasks.Add(item);
    }
}
