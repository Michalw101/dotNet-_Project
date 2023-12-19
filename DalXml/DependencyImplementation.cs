namespace Dal;
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

internal class DependencyImplementation : IDependency
{
    public int Create(Dependency item)
    {
        XElement dependency = new XElement("dependency",
            new XElement("id", item.Id),
            new XElement("dependentTask", item.DependentTask),
            new XElement("dependsOnTask", item.DependsOnTask));
        return item.Id;
    }

    public void Delete(int id)
    {

        XMLTools.LoadListFromXMLElement("dependencies")
            .Elements()
            .FirstOrDefault((element) => Convert.ToInt32(element.Element("id")?.Value) == id)?
            .Remove();
    }

    public Dependency? Read(int id)
    {
           
       XElement? dependency = XMLTools.LoadListFromXMLElement("dependencies")
            .Elements()
            .FirstOrDefault((element) => Convert.ToInt32(element.Element("id")?.Value) == id);
        return new Dependency(Convert.ToInt32(dependency?.Element("id")?.Value), Convert.ToInt32(dependency?.Element("dependentTask")?.Value), Convert.ToInt32(dependency?.Element("dependsOnTask")?.Value));
    }

    public Dependency? Read(Func<Dependency, bool> filter)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Dependency?> ReadAll(Func<Dependency, bool>? filter = null)
    {
        throw new NotImplementedException();
    }

    public void Update(Dependency item)
    {
        throw new NotImplementedException();
    }
}
