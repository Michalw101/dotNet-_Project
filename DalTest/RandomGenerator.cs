﻿using DalApi;
using DO;
using System.Diagnostics;
using System;

namespace DalTest;

/// <summary>
/// Class for generating random values.
/// </summary>
internal class RandomGenerator //class for generate first value by random
{
    public const int MIN_ID = 200000000;
    public const int MAX_ID = 400000000;
    private static readonly Random s_rand = new();

    /// <summary>
    /// Generates a random engineer name.
    /// </summary>
    /// <returns>A randomly generated engineer name.</returns>
    public string GenerateEngineerName() //return random name
    {
        string[] _firstName = new string[] { "Adam", "Alex", "Aaron", "Ben", "Carl", "Dan", "David", "Edward", "Fred", "Frank", "George", "Hal", "Hank", "Ike", "John", "Jack", "Joe", "Larry", "Monte", "Matthew", "Mark", "Nathan", "Otto", "Paul", "Peter", "Roger", "Roger", "Steve", "Thomas", "Tim", "Ty", "Victor", "Walter" };
        string[] _lastName = new string[] { "Anderson", "Ashwoon", "Aikin", "Bateman", "Bongard", "Bowers", "Boyd", "Cannon", "Cast", "Deitz", "Dewalt", "Ebner", "Frick", "Hancock", "Haworth", "Hesch", "Hoffman", "Kassing", "Knutson", "Lawless", "Lawicki", "Mccord", "McCormack", "Miller", "Myers", "Nugent", "Ortiz", "Orwig", "Ory", "Paiser", "Pak", "Pettigrew", "Quinn", "Quizoz", "Ramachandran", "Resnick", "Sagar", "Schickowski", "Schiebel", "Sellon", "Severson", "Shaffer", "Solberg", "Soloman", "Sonderling", "Soukup", "Soulis", "Stahl", "Sweeney", "Tandy", "Trebil", "Trusela", "Trussel", "Turco", "Uddin", "Uflan", "Ulrich", "Upson", "Vader", "Vail", "Valente", "Van Zandt", "Vanderpoel", "Ventotla", "Vogal", "Wagle", "Wagner", "Wakefield", "Weinstein", "Weiss", "Woo", "Yang", "Yates", "Yocum", "Zeaser", "Zeller", "Ziegler", "Bauer", "Baxster", "Casal", "Cataldi", "Caswell", "Celedon", "Chambers", "Chapman", "Christensen", "Darnell", "Davidson", "Davis", "DeLorenzo", "Dinkins", "Doran", "Dugelman", "Dugan", "Duffman", "Eastman", "Ferro", "Ferry", "Fletcher", "Fietzer", "Hylan", "Hydinger", "Illingsworth", "Ingram", "Irwin", "Jagtap", "Jenson", "Johnson", "Johnsen", "Jones", "Jurgenson", "Kalleg", "Kaskel", "Keller", "Leisinger", "LePage", "Lewis", "Linde", "Lulloff", "Maki", "Martin", "McGinnis", "Mills", "Moody", "Moore", "Napier", "Nelson", "Norquist", "Nuttle", "Olson", "Ostrander", "Reamer", "Reardon", "Reyes", "Rice", "Ripka", "Roberts", "Rogers", "Root", "Sandstrom", "Sawyer", "Schlicht", "Schmitt", "Schwager", "Schutz", "Schuster", "Tapia", "Thompson", "Tiernan", "Tisler" };
        string[] results = new string[2];
        results[0] = _firstName[s_rand.Next(_firstName.Length)];
        results[1] = _lastName[s_rand.Next(_lastName.Length)];
        return results[0] + " " + results[1];
    }

    /// <summary>
    /// Generates a random engineer ID.
    /// </summary>
    /// <returns>A randomly generated engineer ID.</returns>
    public int GenerateEngineerID() //return random id
    {
        int id = s_rand.Next(MIN_ID, MAX_ID);
        return id;
    }

    /// <summary>
    /// Generates a random engineer level.
    /// </summary>
    /// <returns>A randomly generated engineer level.</returns>
    public int GenerateEngineerLevel() //return random level
    {
        int level = s_rand.Next(0, 3);
        return level;
    }

    /// <summary>
    /// Generates a random engineer cost.
    /// </summary>
    /// <returns>A randomly generated engineer cost.</returns>
    public double GenerateEngineerCost() //return random level
    {
        double cost = s_rand.Next(35, 50);
        return cost;
    }

    /// <summary>
    /// Generates an array of random task descriptions.
    /// </summary>
    /// <returns>An array of randomly generated task descriptions.</returns>
    public string[] GenerateTaskDescription() //return an array of tasks
    {
        string[] tasks = {"Design and analyze engineering projects",
                          "Prototype, test, and optimize designs",
                          "Manage projects and mitigate risks",
                          "Ensure quality and compliance with standards",
                          "Create and maintain engineering documentation",
                          "Engage in research and development",
                          "Collaborate and communicate effectively",
                          "Adhere to regulatory requirements",
                          "Drive continuous process improvement",
                          "Interact with clients and provide support",
                          "Design and optimize electrical circuits",
                          "Conduct feasibility studies for projects",
                          "Perform data analysis and interpretation",
                          "Develop and implement safety protocols",
                          "Troubleshoot and repair mechanical systems",
                          "Manage and coordinate project timelines",
                          "Conduct market research for product development",
                          "Implement and maintain cybersecurity measures",
                          "Perform energy efficiency assessments",
                          "Collaborate on hardware and firmware development" };
        return tasks;
    }

    /// <summary>
    /// Generates an array of random task aliases.
    /// </summary>
    /// <returns>An array of randomly generated task aliases.</returns>
    public string[] GenerateTaskAlias() //return an aray for aliases
    {
        string[] aliases = {
            "Engineering Design and Analysis",
            "Prototype Development and Testing",
            "Project Planning and Management",
            "Quality Assurance and Compliance",
            "Documentation and Record-keeping",
            "Research and Development",
            "Collaboration and Communication",
            "Regulatory Compliance Management",
            "Continuous Process Improvement",
            "Client Interaction and Support",

            "Algorithm Development and Implementation",
            "Technical Troubleshooting and Debugging",
            "Code Optimization and Efficiency",
            "Cross-functional Collaboration",
            "System Testing and Validation",
            "Database Design and Maintenance",
            "User Interface Creation",
            "Emerging Technologies Awareness",
            "Technical Documentation Writing and Review",
            "End-user Training and Support",

            "Electrical Circuit Design and Optimization",
            "Feasibility Study Conducting",
            "Data Analysis and Interpretation",
            "Safety Protocol Development",
            "Mechanical System Troubleshooting and Repair",
            "Project Timeline Management",
            "Market Research for Product Development",
            "Cybersecurity Measures Implementation",
            "Energy Efficiency Assessments",
            "Hardware and Firmware Development Collaboration"
        };
        return aliases;
    }

    // <summary>
    /// Generates an array of random schedules.
    /// </summary>
    /// <returns>An array of randomly generated schedules.</returns>
    public double[] GenerateSchedual() //return an array of schedual
    {
        double[] schedual = {
          3,  // Engineering Design and Analysis
          4.5,  // Prototype Development and Testing
          6,  // Project Planning and Management
          2,  // Code Optimization and Efficiency
          4,  // Cross-functional Collaboration (Ongoing)
          4,  // System Testing and Validation
          4.5,  // Database Design and Maintenance
          3,  // User Interface Creation
          6,  // Emerging Technologies Awareness (Ongoing)
          1.5,  // Technical Documentation Writing and Review
          7,  // End-user Training and Support (Ongoing)
          4.5,  // Electrical Circuit Design and Optimization
          3,  // Feasibility Study Conducting
          3.5,  // Data Analysis and Interpretation
          3,  // Safety Protocol Development
          4,  // Mechanical System Troubleshooting and Repair
          2.5,  // Project Timeline Management (Ongoing)
          6,  // Market Research for Product Development
          4.5,  // Cybersecurity Measures Implementation
          3,  // Energy Efficiency Assessments
          7,  // Hardware and Firmware Development Collaboration
        };
        return schedual;
    }

    /// <summary>
    /// Selects an engineer for a task.
    /// </summary>
    /// <param name="engineers">The list of engineers.</param>
    /// <param name="_level">The level of the engineer.</param>
    /// <param name="tasks">The list of tasks.</param>
    /// <returns>The ID of the selected engineer.</returns>
    public int EngineerForTask(List<Engineer?> engineers, EngineerExperience _level, List<DO.Task?> tasks)
    {
        int id;
        bool found;
        do
        {
            found = false;
            int index = s_rand.Next(0, engineers.Count);
            id = engineers[index]!.Id;
            foreach (var task in tasks)
            {
                if (task != null && task.EngineerId == id)
                {
                    found = true;
                    break;
                }
            }
        }
        while (found || engineers.FirstOrDefault(e => e != null && e.Level == _level) == null);

        return id;
    }

    /// <summary>
    /// Generates the ID of a dependent task.
    /// </summary>
    /// <param name="tasks">The list of tasks.</param>
    /// <returns>The ID of the dependent task.</returns>
    public int GenerateDependentTask(List<DO.Task?> tasks) //return random task's id
    {
        int i, id;
        i = s_rand.Next(0, tasks.Count());
        id = tasks[i]!.Id;
        return id;
    }

    /// <summary>
    /// Generates the ID of a task that another task depends on.
    /// </summary>
    /// <param name="tasks">The list of tasks.</param>
    /// <param name="dependentId">The ID of the dependent task.</param>
    /// <returns>The ID of the task that another task depends on.</returns>
    public int GenerateDepensOnTask(List<DO.Task?> tasks, int dependentId) //return random task's id
    {
        int i, id;
        i = s_rand.Next(0, dependentId);
        id = tasks[i]!.Id;
        return id;
    }

}