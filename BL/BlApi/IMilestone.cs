namespace BlApi
{

    /// <summary>
    /// Represents the interface for Milestone operations.
    /// </summary>
    public interface IMilestone
    {
        /// <summary>
        /// Creates a new Milestone with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Milestone to create.</param>
        /// <returns>The newly created Milestone object.</returns>
        public BO.Milestone Create(int id);

        /// <summary>
        /// Updates the Milestone with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Milestone to update.</param>
        /// <returns>The updated Milestone object.</returns>
        public BO.Milestone Update(int id);
    }
}
