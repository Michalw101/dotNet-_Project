namespace BlImplementation;
using BlApi;
using System;
using System.Collections.Generic;

internal class TaskImplementation : ITask
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    public int Create(BO.Task item)
    {
        bool isMilestone = false;
        // בדיקת תקינות
        if (item.Dependencies != null)
        {
            isMilestone = true;
            var listDep = from BO.TaskInList dependency in item.Dependencies!
                          select new DO.Dependency(0, item.Id, dependency.Id);
            listDep.Select(dep => _dal.Dependency.Create(dep));
        }
        TimeSpan requiredEffortTime = new TimeSpan(Convert.ToInt32(item.DeadlineDate - item.StartDate));
        DO.Task doTask = new DO.Task
               (0, item.Alias, item.Description, isMilestone, item.CreatedAtDate, item.Engineer?.Id,
               (DO.EngineerExperience?)item.ComplexityLevel, requiredEffortTime,
               item.StartDate, item.ScheduledStartDate, item.DeadlineDate,
               item.Remarks, item.CompleteDate, item.Deliverables);
        _dal.Task.Create(doTask);
        return item.Id;
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
                                          Milestone = new BO.MilestoneInTask { Id = 0, Alias = "aa" },
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

