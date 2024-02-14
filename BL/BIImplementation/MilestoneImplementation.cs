namespace BlImplementation;
using BlApi;
using BO;


/// <summary>
/// Represents the implementation class for Milestone operations.
/// </summary>
internal class MilestoneImplementation : IMilestone
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    /// <summary>
    /// Creates a Milestone with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the Milestone to create.</param>
    /// <returns>The newly created Milestone.</returns>
    public Milestone Create(int id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates the Milestone with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the Milestone to update.</param>
    /// <returns>The updated Milestone.</returns>
    public Milestone Update(int id)
    {
        throw new NotImplementedException();
    }
}


