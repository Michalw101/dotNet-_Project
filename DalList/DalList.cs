namespace Dal;

using DalApi;

/// <summary>
/// Represents a concrete implementation of the <see cref="IDal"/> interface using in-memory lists.
/// </summary>
sealed internal class DalList : IDal
{
    /// <summary>
    /// Gets an instance of the <see cref="IEngineer"/> interface for CRUD operations on engineers.
    /// </summary>
    public IEngineer Engineer => new EngineerImplementation();

    /// <summary>
    /// Gets an instance of the <see cref="ITask"/> interface for CRUD operations on tasks.
    /// </summary>
    public ITask Task => new TaskImplementation();

    /// <summary>
    /// Gets an instance of the <see cref="IDependency"/> interface for CRUD operations on dependencies.
    /// </summary>
    public IDependency Dependency => new DependencyImplementation();

    //public static IDal Instance { get; } = new DalList();

    //Lazy - כדי להשהות את יצירת האובייקט עד שבטוח צריכים אותו
    //Theard safe - כדי להבטיח שתהליכים מקבילים לא יפריעו זה לזה
    private static readonly Lazy<DalList> lazyInstance = new Lazy<DalList>(() => new DalList(), true);

    /// <summary>
    /// Gets the singleton instance of the <see cref="DalList"/> class.
    /// </summary>
    public static IDal Instance => lazyInstance.Value;
    private DalList() { }
}
