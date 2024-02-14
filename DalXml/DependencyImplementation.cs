using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Dal
{
    /// <summary>
    /// Implementation of the IDependency interface for data access operations related to dependencies.
    /// </summary>
    internal class DependencyImplementation : IDependency
    {
        /// <summary>
        /// Creates a new dependency.
        /// </summary>
        /// <param name="item">The dependency to create.</param>
        /// <returns>The ID of the newly created dependency.</returns>
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

        /// <summary>
        /// Deletes a dependency.
        /// </summary>
        /// <param name="id">The ID of the dependency to delete.</param>
        public void Delete(int id)
        {
            XMLTools.LoadListFromXMLElement("dependencies")
                .Elements()
                .FirstOrDefault((element) => Convert.ToInt32(element.Element("id")?.Value) == id)?
                .Remove();
        }
        /// <summary>
        /// Reads a dependency by its ID.
        /// </summary>
        /// <param name="id">The ID of the dependency to read.</param>
        /// <returns>The dependency with the specified ID.</returns>
        public Dependency? Read(int id)
        {
            XElement? dependency = XMLTools.LoadListFromXMLElement("dependencies")
                .Elements()
                .FirstOrDefault((element) => Convert.ToInt32(element.Element("id")?.Value) == id);
            return new Dependency(Convert.ToInt32(dependency?.Element("id")?.Value), Convert.ToInt32(dependency?.Element("dependentTask")?.Value), Convert.ToInt32(dependency?.Element("dependsOnTask")?.Value));
        }

        /// <summary>
        /// Reads a dependency based on a filter.
        /// </summary>
        /// <param name="filter">The filter condition.</param>
        /// <returns>The dependency that satisfies the filter condition.</returns>
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

        /// <summary>
        /// Reads all dependencies based on an optional filter.
        /// </summary>
        /// <param name="filter">The optional filter condition.</param>
        /// <returns>A collection of dependencies that satisfy the filter condition.</returns>
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

        /// <summary>
        /// Updates an existing dependency.
        /// </summary>
        /// <param name="item">The dependency to update.</param>
        public void Update(Dependency item)
        {
            XElement list = XMLTools.LoadListFromXMLElement("dependencies");
            list.Elements()
                .FirstOrDefault((element) => Convert.ToInt32(element.Element("id")?.Value) == item.Id)?
                .Remove();
            list.Add(new Dependency(item.Id, item.DependentTask, item.DependsOnTask));
            XMLTools.SaveListToXMLElement(list, "dependencies");
        }
    }
}
