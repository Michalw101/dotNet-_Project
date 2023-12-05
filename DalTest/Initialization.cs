namespace DalTest;
using DalApi;
using DO;
using System.Security.Cryptography;
using System.Xml.Linq;

public static class Initialization 
{
    private static IDal? s_dal;
    private static RandomGenerator r = new RandomGenerator();

    //initialization values for all the lists
    public static void DO(IDal dal)
    {
        s_dal = dal ?? throw new NullReferenceException("DAL object can not be null!");
        createEngineers();
        createTasks();
        createDependency();
    }
    public static void createEngineers() 
    {
        string[] names = new string[10];
        int _id;
        string _email;
        for (int i = 0; i < names.Length; i++)
        {
            names[i] = r.GenerateEngineerName();
        }
        foreach (var _name in names)
        {
            if (s_dal!.Engineer != null)
            {
                do
                    _id = r.GenerateEngineerID();
                while (s_dal!.Engineer.Read(_id) != null);
            }
            else
                _id = r.GenerateEngineerID();
            _email = _name.Split(" ")[0] + "@exapmle.com";
            EngineerExperience _level = (EngineerExperience)r.GenerateEngineerLevel();
            Engineer newEngineer = new(_id, _name, _email, _level);
            s_dal!.Engineer!.Create(newEngineer);
        }
    }
    public static void createTasks()
    {
        string[] descriptions = r.GenerateTaskDescription();
        string[] aliases = r.GenerateTaskAlias();
        double[] weeks = r.GenerateSchedual();
        string _description, _alias;
        DateTime _crearedAt, _forecastDate, _deadLine;
        EngineerExperience _complexityLevel;
        List<Engineer?> list =s_dal!.Engineer.ReadAll().ToList();
        int _engineerId;
        for (int i = 0; i < descriptions.Length; i++)
        {
            _description = descriptions[i];
            _alias = aliases[i];
            _crearedAt = DateTime.Now;
            _forecastDate = _crearedAt.AddDays(weeks[i] * 7);
            _deadLine = _forecastDate.AddDays(7);
            _complexityLevel = (EngineerExperience)r.GenerateEngineerLevel();
            _engineerId = r.EngineerForTask(list, _complexityLevel);
            Task newTask = new(0, _description, _crearedAt, _forecastDate, _deadLine, _engineerId, _complexityLevel, _alias);
            s_dal.Task!.Create(newTask);
        }
    }
  
    public static void createDependency()
    {
        List<Task?> list = s_dal!.Task.ReadAll().ToList();
        for (int i = 0; i < 10; i++)
        {
            int _dependentId = r.GenerateDependentTask(list);
            int _dependsOnId = r.GenerateDepensOnTask(list, _dependentId);
            Dependency newDependency = new(0, _dependentId, _dependsOnId);
            s_dal!.Dependency.Create(newDependency);
        }
    }

}
