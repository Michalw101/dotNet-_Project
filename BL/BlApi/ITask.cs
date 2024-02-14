namespace BlApi
{

    /// <summary>
    /// Represents the interface for operations related to Tasks.
    /// </summary>
    public interface ITask
    {
        /// <summary>
        /// Creates a new Task.
        /// </summary>
        /// <param name="item">The Task object to create.</param>
        /// <returns>The ID of the newly created Task.</returns>
        public int Create(BO.Task item);

        /// <summary>
        /// Reads a Task with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Task to read.</param>
        /// <returns>The Task object if found, null otherwise.</returns>
        public BO.Task? Read(int id);

        /// <summary>
        /// Reads all Tasks based on the provided filter.
        /// </summary>
        /// <param name="filter">The filter function to apply on Tasks (optional).</param>
        /// <returns>A collection of Task objects that match the filter.</returns>
        public IEnumerable<BO.Task?> ReadAll(Func<BO.Task, bool>? filter = null);

        /// <summary>
        /// Updates an existing Task.
        /// </summary>
        /// <param name="item">The Task object to update.</param>
        public void Update(BO.Task item);

        /// <summary>
        /// Deletes a Task with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Task to delete.</param>
        public void Delete(int id);
    }
}
