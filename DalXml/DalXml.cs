using DalApi;
using System.Diagnostics;

namespace Dal;

sealed internal class DalXml : IDal
{
    public IEngineer Engineer => new EngineerImplementation();

    public ITask Task => new TaskImplementation();

    public IDependency Dependency => new DependencyImplementation();

    //public static IDal Instance { get; } = new DalXml();

    private static readonly Lazy<DalXml> lazyInstance = new Lazy<DalXml>(() => new DalXml(), true);

    public static IDal Instance => lazyInstance.Value;
    private DalXml() { }
}
