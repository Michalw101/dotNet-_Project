using BlApi;
using BO;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlImplementation
{
    /// <summary>
    /// Implements business logic operations related to tasks.
    /// </summary>
    internal class TaskImplementation : ITask
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="item">The task to create.</param>
        /// <returns>The ID of the created task.</returns>
        public int Create(BO.Task item)
        {
            bool isMilestone = false;

            // Check for validity
            if (item.Dependencies != null)
            {
                isMilestone = true;
                var listDep = from BO.TaskInList dependency in item.Dependencies!
                              select new DO.Dependency(0, item.Id, dependency.Id);
                listDep.Select(dep => _dal.Dependency.Create(dep));
            }

            TimeSpan? requiredEffortTime = item.DeadlineDate - item.StartDate;

            DO.Task doTask = new DO.Task
                   (0, item.Alias, item.Description, isMilestone, item.CreatedAtDate, item.Engineer?.Id,
                   (DO.EngineerExperience?)item.ComplexityLevel, requiredEffortTime,
                   item.StartDate, item.ScheduledStartDate, item.DeadlineDate,
                   item.Remarks, item.CompleteDate, item.Deliverables);

            _dal.Task.Create(doTask);

            return item.Id;
        }

        /// <summary>
        /// Deletes a task by its ID.
        /// </summary>
        /// <param name="id">The ID of the task to delete.</param>
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a task by its ID.
        /// </summary>
        /// <param name="id">The ID of the task to read.</param>
        /// <returns>The task with the specified ID.</returns>
        public BO.Task? Read(int id)
        {
            DO.Task? doTask = _dal.Task.Read(id);

            if (doTask == null)
                throw new BO.BlDoesNotExistException($"Task with ID={id} does Not exist");

            return MapToBOTask(doTask);
        }

        /// <summary>
        /// Reads all tasks.
        /// </summary>
        /// <param name="filter">An optional filter to apply.</param>
        /// <returns>An enumerable collection of tasks.</returns>
        public IEnumerable<BO.Task?> ReadAll(Func<BO.Task, bool>? filter = null)
        {
            IEnumerable<BO.Task?> query =
                from DO.Task? doTask in _dal.Task.ReadAll()
                select doTask != null ? MapToBOTask(doTask) : null;

            if (filter != null)
            {
                query = query.Where(e => e != null && filter(e));
            }

            return query;
        }

        private BO.Task MapToBOTask(DO.Task doTask)
        {
            return new BO.Task()
            {
                Id = doTask.Id,
                Description = doTask.Description ?? "", // Provide default value if null
                Alias = doTask.Alias ?? "", // Provide default value if null
                CreatedAtDate = doTask.CreatedAtDate,
                Status = Status.Scheduled,
                Milestone = new BO.MilestoneInTask { Id = 0, Alias = "aa" },
                ScheduledStartDate = doTask.ScheduledDate ?? DateTime.MinValue, // Provide default value if null
                StartDate = doTask.StartDate ?? DateTime.MinValue, // Provide default value if null
                DeadlineDate = doTask.DeadlineDate ?? DateTime.MinValue, // Provide default value if null
                CompleteDate = doTask.CompleteDate ?? DateTime.MinValue, // Provide default value if null
                Deliverables = doTask.Deliverables ?? "", // Provide default value if null
                Remarks = doTask.Remarks ?? "", // Provide default value if null
                ComplexityLevel = (BO.EngineerExperience?)doTask.ComplexityLevel // Provide default value if null
            };
        }

        /// <summary>
        /// Updates an existing task.
        /// </summary>
        /// <param name="item">The task to update.</param>
        public void Update(BO.Task item)
        {
            DO.Task? doTask = new DO.Task(
                       item.Id,
                       item.Alias,
                       item.Description,
                       item.Milestone != null ? true : false,
                       item.CreatedAtDate,
                       item.Engineer != null ? item.Engineer.Id : null,
                       item.ComplexityLevel != null ? (DO.EngineerExperience)item.ComplexityLevel : null,
                       item.ForecastDate - item.ScheduledStartDate,
                       item.StartDate,
                       item.ScheduledStartDate,
                       item.DeadlineDate,
                       item.Remarks,
                       item.CompleteDate,
                       item.Deliverables);

            try
            {
                _dal.Task.Update(doTask);
            }
            catch (DalDoesNotExistException ex)
            {
                throw new BO.BlDoesNotExistException($"Task with ID = {item.Id} does not exist", ex);
            }
        }
    }
}
