namespace BlImplementation;
using BlApi;
using System;
using System.Collections.Generic;

internal class TaskImplementation : ITask
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    public int Create(BO.Task item)
    {
        DO.Task doTask = new DO.Task
        (item.Id, item.Description, item.Alias, false, item.CreatedAtDate);
        try
        {
            int idTask = _dal.Task.Create(doTask);
            return idTask;
        }
        catch (DO.DalAlreadyExistsException ex)
        {
            throw new BO.BlAlreadyExistsException($"Task with ID={item.Id} already exists", ex);
        }

    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public BO.Task? Read(int id)
    {
        DO.Task? doTask = _dal.Task.Read(id);
        if (doTask == null)
            throw new BO.BlDoesNotExistException($"Task with ID={id} does Not exist");

        return new BO.Task()
        {
            Id = id,
            Description = doTask.Description,
            Alias = doTask.Alias,
            CreatedAtDate = doTask.CreatedAtDate,
            Status = BO.Status.Scheduled,
            Milestone = new BO.MilestoneInTask { Id = 0, Alias = "aa" },
            ComplexityLevel = (BO.EngineerExperience?)doTask.ComplexityLevel
        };

    }

    public IEnumerable<BO.Task?> ReadAll(Func<BO.Task, bool>? filter = null)
    {
        IEnumerable<BO.Task?> query = from DO.Task doTask in _dal.Task.ReadAll()
                                          select new BO.Task
                                          {
                                              Id = doTask!.Id,
                                              Description = doTask.Description,
                                              Alias = doTask.Alias,
                                              CreatedAtDate = doTask.CreatedAtDate,
                                              Status = BO.Status.Scheduled,
                                              Milestone = new BO.MilestoneInTask {Id = 0,Alias = "aa" },
                                              ComplexityLevel = (BO.EngineerExperience?)doTask.ComplexityLevel
                                          };



        if (filter != null)
        {
            query = query.Where(e => filter(e!));
        }

        return query;
    }

    public void Update(BO.Task item)
    {
        throw new NotImplementedException();
    }
}

