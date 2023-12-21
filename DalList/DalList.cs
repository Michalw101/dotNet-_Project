namespace Dal;

using DalApi;
sealed internal class DalList : IDal
{
    public IEngineer Engineer => new EngineerImplementation();

    public ITask Task => new TaskImplementation();

    public IDependency Dependency => new DependencyImplementation();

    //public static IDal Instance { get; } = new DalList();

    //Lazy - כדי להשהות את יצירת האובייקט עד שבטוח צריכים אותו
    //Theard safe - כדי להבטיח שתהליכים מקבילים לא יפריעו זה לזה
    private static readonly Lazy<DalList> lazyInstance = new Lazy<DalList>(() => new DalList(), true);

    public static IDal Instance => lazyInstance.Value;
    private DalList() { }
}
