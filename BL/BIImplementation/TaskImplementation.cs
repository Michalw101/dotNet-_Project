using BlApi;
using BO;
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace BlImplementation
{
    /// <summary>
    /// Implements business logic operations related to tasks.
    /// </summary>
    internal class TaskImplementation : BlApi.ITask
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="item">The task object containing details of the new task.</param>
        /// <returns>The ID of the newly created task.</returns>
        /// <exception cref="BO.BlUnvalidException">Thrown when provided task data is invalid.</exception>

        public int Create(BO.Task item)
        {
            // Check for validity
            if (string.IsNullOrEmpty(item.Alias))
                throw new BO.BlUnvalidException("Alias cannot be empty");

            if (item.Dependencies != null)
            {
                foreach (var dependency in item.Dependencies)
                {
                    if (dependency.Id <= 0)
                        throw new BO.BlUnvalidException("Invalid dependency ID");
                }
            }

            // Determine if the task is a milestone
            bool isMilestone = item.Dependencies != null && item.Dependencies.Any();

            // Create dependencies
            if (isMilestone)
            {
                foreach (var dependency in item.Dependencies!)
                {
                    DO.Dependency doDependency = new DO.Dependency(0, item.Id, dependency.Id);
                    _dal.Dependency.Create(doDependency);
                }
            }

            TimeSpan? requiredEffortTime = null;

            // Calculate required effort time
            if (item.StartDate != null && item.DeadlineDate != null)
            {
                if (item.StartDate >= item.DeadlineDate)
                    throw new BO.BlUnvalidException("Start date must be before deadline date");
                requiredEffortTime = item.DeadlineDate - item.StartDate;
            }

            // Create the task object
            DO.Task doTask = new DO.Task(
                0,
                item.Alias,
                item.Description,
                isMilestone,
                item.CreatedAtDate,
                item.Engineer?.Id,
                (DO.EngineerExperience?)item.ComplexityLevel,
                requiredEffortTime,
                item.StartDate,
                item.ScheduledStartDate,
                item.DeadlineDate,
                item.Remarks,
                item.CompleteDate,
                item.Deliverables);

            // Persist the task in the data store
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
                query = query.Where(e => filter(e!));
            }

            return query;
        }

        private BO.Task MapToBOTask(DO.Task doTask)
        {
            DO.Task? task = null;
            IEnumerable<DO.Dependency?> list = _dal.Dependency.ReadAll().Where(dep => dep != null && dep.DependsOnTask == doTask.Id);
            List<BO.TaskInList> dependencies = new List<BO.TaskInList>();
            foreach (DO.Dependency? dep in list)
            {
                if (dep != null)
                {
                    task = _dal.Task.Read(dep.DependentTask);
                    if (task != null)
                    {
                        dependencies.Add(new BO.TaskInList()
                        {
                            Id = task.Id,
                            Description = task.Description,
                            Alias = task.Alias,
                            Status = CheckStatus(task)
                        });
                    }
                }
            }


            BO.EngineerInTask? BOengineer = null;
            if (doTask.EngineerId != 0)
            {
                DO.Engineer? DOengineer = _dal.Engineer.Read(Convert.ToInt32(doTask.EngineerId));
                BOengineer = new BO.EngineerInTask() { Id = DOengineer!.Id, Name = DOengineer.Name };
            }
               
            return new BO.Task()
            {
                Id = doTask.Id,
                Description = doTask.Description ?? "", // Provide default value if null
                Alias = doTask.Alias ?? "", // Provide default value if null
                CreatedAtDate = doTask.CreatedAtDate,
                Status = CheckStatus(doTask),
                Milestone = null,
                ScheduledStartDate = doTask.ScheduledDate,
                StartDate = doTask.StartDate,
                DeadlineDate = doTask.DeadlineDate,
                CompleteDate = doTask.CompleteDate,
                Deliverables = doTask.Deliverables ?? "", // Provide default value if null
                Remarks = doTask.Remarks ?? "", // Provide default value if null
                ComplexityLevel = (BO.EngineerExperience?)doTask.ComplexityLevel,
                Dependencies = dependencies,
                Engineer = BOengineer
            };
        }
        private Status CheckStatus(DO.Task doTask)
        {
            Status status;
            if (doTask.CompleteDate < DateTime.Now)
                status = Status.Done;
            else if (doTask.ScheduledDate > DateTime.Now || doTask.ScheduledDate == null)
                status = Status.Unscheduled;
            else if (doTask.StartDate < DateTime.Now)
                status = Status.OnTrack;
            else
                status = Status.Scheduled;
            return status;
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
