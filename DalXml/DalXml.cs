using DalApi;
using System.Diagnostics;

namespace Dal
{
    /// <summary>
    /// Represents a XML data access layer implementation.
    /// </summary>
    internal sealed class DalXml : IDal
    {
        /// <summary>
        /// Gets an instance of the engineer data access interface.
        /// </summary>
        public IEngineer Engineer => new EngineerImplementation();

        /// <summary>
        /// Gets an instance of the task data access interface.
        /// </summary>
        public ITask Task => new TaskImplementation();

        /// <summary>
        /// Gets an instance of the dependency data access interface.
        /// </summary>
        public IDependency Dependency => new DependencyImplementation();

        /// <summary>
        /// Gets the singleton instance of the DalXml class.
        /// </summary>
        public static IDal Instance { get; } = new DalXml();

        //private static readonly Lazy<DalXml> lazyInstance = new Lazy<DalXml>(() => new DalXml(), true);

        //public static IDal Instance => lazyInstance.Value;

        /// <summary>
        /// Initializes a new instance of the DalXml class.
        /// </summary>
        private DalXml() { }
    }
}