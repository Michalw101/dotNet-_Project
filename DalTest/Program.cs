using Dal;
using DalApi;
using DO;

namespace DalTest
{
    internal class Program
    {
        private static IEngineer? s_dalEngineer = new EngineerImplementation();
        private static ITask? s_dalTask = new TaskImplementation();
        private static IDependency? s_dalDependency = new DependencyImplementation();
        private static void EngineerMethods()
        {
            Console.WriteLine("Enter your choice: \n 0- Exit \n 1- Create \n 2- Read \n 3- ReadAll \n 4- Update \n 5- Delete");
            int id;
            double? cost;
            int choice = Convert.ToInt32(Console.ReadLine());
            string? name, email, input;
            Engineer? engineer;
            EngineerExperience level;
            switch (choice)
            {
                case 0:
                    System.Environment.Exit(0);
                    break;
                case 1:
                    Console.WriteLine("Enter engineer details : id, name, email, level(0 - rookie, 1 - junior, 2 - expert), cost");
                    id = Convert.ToInt32(Console.ReadLine() ?? throw new Exception("id can not be null"));
                    name = Console.ReadLine() ?? throw new Exception("name can not be null");
                    email = Console.ReadLine() ?? throw new Exception("email can not be null");
                    level = (EngineerExperience)Convert.ToInt32(Console.ReadLine() ?? throw new Exception("level can not be null"));
                    cost = Convert.ToInt32(Console.ReadLine());
                    engineer = new Engineer(id, name, email, level, cost);
                    s_dalEngineer!.Create(engineer);
                    break;
                case 2:
                    Console.WriteLine("Enter ID");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(s_dalEngineer!.Read(id));
                    break;
                case 3:
                    List<Engineer> list = s_dalEngineer!.ReadAll();
                    foreach (var item in list)
                        Console.WriteLine(item);
                    break;
                case 4:
                    Console.WriteLine("Enter ID");
                    id = Convert.ToInt32(Console.ReadLine());
                    engineer = s_dalEngineer!.Read(id);
                    Console.WriteLine(engineer);
                    Console.WriteLine("Enter engineer details : id, name, email, level (0 - rookie, 1 - junior, 2 - expert), cost");
                    input = Console.ReadLine();
                    id = (input == "") ? engineer!.Id : Convert.ToInt32(input);
                    input = Console.ReadLine();
                    name = (input == "") ? engineer!.Name : input;
                    input = Console.ReadLine();
                    email = (input == "") ? engineer!.Email : input;
                    input = Console.ReadLine();
                    level = (input == "") ? engineer!.Level : (EngineerExperience)Convert.ToInt32(input);
                    input = Console.ReadLine();
                    cost = (input == "") ? engineer!.Cost : Convert.ToDouble(input);
                    break;
                case 5:
                    Console.WriteLine("Enter ID");
                    id = Convert.ToInt32(Console.ReadLine());
                    s_dalEngineer!.Delete(id);
                    
                    break;
            }
        }

        private static void TaskMethods()
        {
            Console.WriteLine("Enter your choice: \n 0- Exit \n 1- Create \n 2- Read \n 3- ReadAll \n 4- Update \n 5- Delete");
            int id, engineerId;
            DateTime createdAt, forecastDate, deadline;
            int choice = Convert.ToInt32(Console.ReadLine());
            string description;
            string? alias, remarks, input;
            DO.Task? task;
            EngineerExperience complexityLevel;
            switch (choice)
            {
                case 0:
                    System.Environment.Exit(0);
                    break;
                case 1:
                    Console.WriteLine("Enter task details : id, description, forecastDate, deadline, engineerId, complexityLevel(0 - rookie, 1 - junior, 2 - expert), alias, remarks");
                    description = Console.ReadLine()!;
                    createdAt = DateTime.Now;
                    forecastDate = Convert.ToDateTime(Console.ReadLine());
                    deadline = Convert.ToDateTime(Console.ReadLine());
                    engineerId = Convert.ToInt32(Console.ReadLine());
                    complexityLevel = (EngineerExperience)Convert.ToInt32(Console.ReadLine() ?? throw new Exception("level can not be null"));
                    alias = Console.ReadLine();
                    remarks= Console.ReadLine();
                    task = new DO.Task(0, description, createdAt,forecastDate,deadline, engineerId, complexityLevel, alias, remarks);
                    s_dalTask!.Create(task);
                    break;
                case 2:
                    Console.WriteLine("Enter ID");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(s_dalTask!.Read(id));
                    break;
                case 3:
                    List<DO.Task?> list = s_dalTask!.ReadAll();
                    foreach (var item in list)
                        Console.WriteLine(item);
                    break;
                case 4:
                    Console.WriteLine("Enter ID");
                    id = Convert.ToInt32(Console.ReadLine());
                    task = s_dalTask!.Read(id);
                    Console.WriteLine(task);
                    Console.WriteLine("Enter task details : id, description, forecastDate, deadline, engineerId, complexityLevel(0 - rookie, 1 - junior, 2 - expert), alias, remarks");
                    input = Console.ReadLine();
                    description = (input == "") ? task!.Description : input!;
                    input = Console.ReadLine();
                    forecastDate = (input == "") ? task!.ForecastDate : Convert.ToDateTime(input);
                    input = Console.ReadLine();
                    deadline = (input == "") ? task!.Deadline : Convert.ToDateTime(input);
                    input = Console.ReadLine();
                    engineerId = (input == "") ? task!.EngineerId : Convert.ToInt32(input);
                    input = Console.ReadLine();
                    complexityLevel = (input == "") ? task!.ComplexityLevel : (EngineerExperience)Convert.ToInt32(input);
                    input = Console.ReadLine();
                    alias = (input == "") ? task!.Alias : input;
                    input = Console.ReadLine();
                    remarks = (input == "") ? task!.Remarks : input;
                    break;
                case 5:
                    Console.WriteLine("Enter ID");
                    id = Convert.ToInt32(Console.ReadLine());
                    s_dalTask!.Delete(id);
                    break;
            }
        }

        private static void DependencyMethods()
        {
            Console.WriteLine("Enter your choice: \n 0- Exit \n 1- Create \n 2- Read \n 3- ReadAll \n 4- Update \n 5- Delete");
            int id, dependentTask, dependsOnTask;
            DateTime createdAt, forecastDate, deadline;
            int choice = Convert.ToInt32(Console.ReadLine());
            string description;
            string? alias, remarks, input;
            Dependency? dependency;
            EngineerExperience complexityLevel;
            switch (choice)
            {
                case 0:
                    System.Environment.Exit(0);
                    break;
                case 1:
                    Console.WriteLine("Enter dependency details : dependent task, depends on task");
                    dependentTask = Convert.ToInt32(Console.ReadLine());
                    dependsOnTask = Convert.ToInt32(Console.ReadLine());
                    dependency = new Dependency(0, dependentTask, dependsOnTask);
                    s_dalDependency!.Create(dependency);
                    break;
                case 2:
                    Console.WriteLine("Enter ID");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(s_dalTask!.Read(id));
                    break;
                case 3:
                    List<DO.Task?> list = s_dalTask!.ReadAll();
                    foreach (var item in list)
                        Console.WriteLine(item);
                    break;
                case 4:
                    Console.WriteLine("Enter ID");
                    id = Convert.ToInt32(Console.ReadLine());
                    task = s_dalTask!.Read(id);
                    Console.WriteLine(task);
                    Console.WriteLine("Enter task details : id, description, forecastDate, deadline, engineerId, complexityLevel(0 - rookie, 1 - junior, 2 - expert), alias, remarks");
                    input = Console.ReadLine();
                    description = (input == "") ? task!.Description : input!;
                    input = Console.ReadLine();
                    forecastDate = (input == "") ? task!.ForecastDate : Convert.ToDateTime(input);
                    input = Console.ReadLine();
                    deadline = (input == "") ? task!.Deadline : Convert.ToDateTime(input);
                    input = Console.ReadLine();
                    engineerId = (input == "") ? task!.EngineerId : Convert.ToInt32(input);
                    input = Console.ReadLine();
                    complexityLevel = (input == "") ? task!.ComplexityLevel : (EngineerExperience)Convert.ToInt32(input);
                    input = Console.ReadLine();
                    alias = (input == "") ? task!.Alias : input;
                    input = Console.ReadLine();
                    remarks = (input == "") ? task!.Remarks : input;
                    break;
                case 5:
                    Console.WriteLine("Enter ID");
                    id = Convert.ToInt32(Console.ReadLine());
                    s_dalTask!.Delete(id);
                    break;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Initialization.DO(s_dalEngineer, s_dalTask, s_dalDependency);
                int choice;
                do
                {
                    Console.WriteLine("Enter your choice: \n 0- Exit \n 1- Engineers \n 2- Tasks \n 3- Dependencies ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 0:
                            System.Environment.Exit(0);
                            break;
                        case 1:
                            EngineerMethods();
                            break;
                        case 2:
                            TaskMethods();
                            break;
                        default:
                            break;

                    }
                }
                while (choice != 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}