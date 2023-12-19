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
        int id = XMLTools.GetAndIncreaseNextId("data-config", "NextDependencyId");
        XElement list = XMLTools.LoadListFromXMLElement("dependencies");
        XElement dependency = new XElement("dependency",
            new XElement("id", id),
            new XElement("dependentTask", item.DependentTask),
            new XElement("dependsOnTask", item.DependsOnTask));
        list.Add(dependency);
        XMLTools.SaveListToXMLElement(list, "dependencies");
        return id;
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
        XElement? dependency = XMLTools.LoadListFromXMLElement("dependencies")
            .Elements()
            .FirstOrDefault((element) => filter(new Dependency(
            Convert.ToInt32(element?.Element("id")?.Value),
            Convert.ToInt32(element?.Element("dependentTask")?.Value),
            Convert.ToInt32(element?.Element("dependsOnTask")?.Value)))
            );
        return new Dependency(
            Convert.ToInt32(dependency?.Element("id")?.Value),
            Convert.ToInt32(dependency?.Element("dependentTask")?.Value),
            Convert.ToInt32(dependency?.Element("dependsOnTask")?.Value)
            );
    }

    public IEnumerable<Dependency?> ReadAll(Func<Dependency, bool>? filter = null)
    {
        IEnumerable<Dependency?> list = XMLTools.LoadListFromXMLElement("dependencies").Elements().Select(element => new Dependency(
            Convert.ToInt32(element?.Element("id")?.Value),
            Convert.ToInt32(element?.Element("dependentTask")?.Value),
            Convert.ToInt32(element?.Element("dependsOnTask")?.Value)
            ));
        if (filter == null)
            return list;
        else
            return list.Where(filter!);
    }

    public void Update(Dependency item)
    {
        XElement list = XMLTools.LoadListFromXMLElement("dependencies");
        list.Elements()
            .FirstOrDefault((element) => Convert.ToInt32(element.Element("id")?.Value) == item.Id)?
            .Remove();
        list.Add(new Dependency(item.Id, item.DependentTask , item.DependsOnTask));
        XMLTools.SaveListToXMLElement(list, "dependencies");
    }
}
