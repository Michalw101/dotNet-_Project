namespace DalApi;
using System.Xml.Linq;
/// <summary>
/// Represents configuration settings for the DAL (Data Access Layer).
static class Config
{
    /// <summary>
    /// Represents an internal PDS (Public Domain Software) class.
    /// </summary>
    internal record DalImplementation
            (string Package, // package/dll name
            string Namespace, // namespace where DAL implementation class is contained in
            string Class // DAL implementation class name 
    );

    /// <summary>
    /// Name of the DAL (Data Access Layer).
    /// </summary>
    internal static string s_dalName;

    /// <summary>
    /// Dictionary containing DAL packages and their implementations.
    /// </summary>
    internal static Dictionary<string, DalImplementation> s_dalPackages;

    /// <summary>
    /// Static constructor to initialize configuration settings.
    /// </summary>
    static Config()
    {
        XElement dalConfig = XElement.Load(@"..\xml\dal-config.xml") ??
       throw new DalConfigException("dal-config.xml file is not found");

        s_dalName =
        dalConfig.Element("dal")?.Value ?? throw new DalConfigException("<dal> element is missing");
        var packages = dalConfig.Element("dal-packages")?.Elements() ??
       throw new DalConfigException("<dal-packages> element is missing");
        s_dalPackages = (from item in packages
                         let pkg = item.Value
                         let ns = item.Attribute("namespace")?.Value ?? "Dal"
                         let cls = item.Attribute("class")?.Value ?? pkg
                         select (item.Name, new DalImplementation(pkg, ns, cls))
       ).ToDictionary(p => "" + p.Name, p => p.Item2);
    }
}
/// <summary>
/// Represents an exception specific to DAL (Data Access Layer) configuration.
/// </summary>
[Serializable]
public class DalConfigException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DalConfigException"/> class with a specified error message.
    /// </summary>
    /// <param name="msg">The message that describes the error.</param>
    public DalConfigException(string msg) : base(msg) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="DalConfigException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="msg">The error message that explains the reason for the exception.</param>
    /// <param name="ex">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>

    public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
}
