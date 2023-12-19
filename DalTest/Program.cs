using Dal;
using DalApi;
using DO;
using DalList;

namespace DalTest
{
    internal class Program
    {
        //static readonly IDal s_dal = new Dal.DalList(); //stage 2
        static readonly IDal s_dal = new Dal.DalXml(); //stage 3
        static void Main(string[] args)
        {
            try
            {
                //Initialization.DO(s_dal); //initialization random values for the lists
                int choice;
                do
                {
                    //main menu
                    Console.WriteLine("Enter your choice: \n 0- Exit \n 1- Engineers \n 2- Tasks \n 3- Dependencies ");
                    int.TryParse(Console.ReadLine(), out choice);
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
                        case 3:
                            DependencyMethods();
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

        private static void EngineerMethods() // engineer manu
        {
            Console.WriteLine("Enter your choice: \n 0- Exit \n 1- Create \n 2- Read \n 3- ReadAll \n 4- Update \n 5- Delete");
            int id;
            double? cost;
            int.TryParse(Console.ReadLine(),out int choice);
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
                    int.TryParse(Console.ReadLine(), out id);
                    name = Console.ReadLine();
                    email = Console.ReadLine();
                    EngineerExperience.TryParse(Console.ReadLine(), out level);
                    cost = Convert.ToDouble(Console.ReadLine());
                    engineer = new Engineer(id, name!, email!, level, cost);
                    s_dal.Engineer.Create(engineer);
                    break;
                case 2:
                    Console.WriteLine("Enter ID");
                    int.TryParse(Console.ReadLine(), out id);
                    Console.WriteLine(s_dal.Engineer.Read(id));
                    break;
                case 3:
                    List<Engineer?> list = s_dal.Engineer.ReadAll().ToList();
                    foreach (var item in list)
                        Console.WriteLine(item);
                    break;
                case 4:
                    Console.WriteLine("Enter ID");
                    int.TryParse(Console.ReadLine(), out id);
                    engineer = s_dal.Engineer.Read(id);
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
                    engineer = new Engineer(id, name!, email!, level, cost);
                    s_dal.Engineer.Update(engineer);
                    break;
                case 5:
                    Console.WriteLine("Enter ID");
                    int.TryParse(Console.ReadLine(), out id);
                    s_dal.Engineer.Delete(id);
                    
                    break;
            }
        }

        private static void TaskMethods() //task menu
        {
            Console.WriteLine("Enter your choice: \n 0- Exit \n 1- Create \n 2- Read \n 3- ReadAll \n 4- Update \n 5- Delete");
            int id, engineerId;
            DateTime createdAt, forecastDate, deadline;
            int.TryParse(Console.ReadLine(), out int choice);
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
                    Console.WriteLine("Enter task details : description, forecastDate, deadline, engineerId, complexityLevel(0 - rookie, 1 - junior, 2 - expert), alias, remarks");
                    description = Console.ReadLine()!;
                    createdAt = DateTime.Now;
                    DateTime.TryParse(Console.ReadLine(), out forecastDate);
                    DateTime.TryParse(Console.ReadLine(),out deadline);
                    int.TryParse(Console.ReadLine(),out engineerId);
                    EngineerExperience.TryParse(Console.ReadLine(), out complexityLevel);
                    alias = Console.ReadLine();
                    remarks= Console.ReadLine();
                    task = new DO.Task(0, description, createdAt,forecastDate,deadline, engineerId, complexityLevel, alias, remarks);
                    s_dal.Task.Create(task);
                    break;
                case 2:
                    Console.WriteLine("Enter ID");
                    int.TryParse(Console.ReadLine(), out id);
                    Console.WriteLine(s_dal.Task.Read(id));
                    break;
                case 3:
                    List<DO.Task?> list = s_dal.Task.ReadAll().ToList();
                    foreach (var item in list)
                        Console.WriteLine(item);
                    break;
                case 4:
                    Console.WriteLine("Enter ID");
                    int.TryParse(Console.ReadLine(), out id);
                    task = s_dal.Task.Read(id);
                    Console.WriteLine(task);
                    Console.WriteLine("Enter task details : id, description, forecastDate, deadline, engineerId, complexityLevel(0 - rookie, 1 - junior, 2 - expert), alias, remarks");
                    input = Console.ReadLine();
                    description = (input == "") ? task!.Description : input!;
                    input = Console.ReadLine();
                    createdAt = task!.CreatedAt;
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
                    task = new DO.Task(id, description, createdAt, forecastDate, deadline, engineerId, complexityLevel, alias, remarks);
                    s_dal.Task.Update(task);
                    break;
                case 5:
                    Console.WriteLine("Enter ID");
                    int.TryParse(Console.ReadLine(), out id);
                    s_dal.Task.Delete(id);
                    break;
            }
        }

        private static void DependencyMethods() //Dependency manu
        {
            Console.WriteLine("Enter your choice: \n 0- Exit \n 1- Create \n 2- Read \n 3- ReadAll \n 4- Update \n 5- Delete");
            int id, dependentTask, dependsOnTask;
            int.TryParse(Console.ReadLine(), out int choice);
            string? input;
            Dependency? dependency;
            switch (choice)
            {
                case 0:
                    System.Environment.Exit(0);
                    break;
                case 1:
                    Console.WriteLine("Enter dependency details : dependent task, depends on task");
                    int.TryParse(Console.ReadLine(), out dependentTask);
                    int.TryParse(Console.ReadLine(), out dependsOnTask);
                    dependency = new Dependency(0, dependentTask, dependsOnTask);
                    s_dal.Dependency.Create(dependency);
                    break;
                case 2:
                    Console.WriteLine("Enter ID");
                    int.TryParse(Console.ReadLine(), out id);
                    Console.WriteLine(s_dal.Dependency.Read(id));
                    break;
                case 3:
                    List<Dependency?> list = s_dal.Dependency.ReadAll().ToList();
                    foreach (var item in list)
                        Console.WriteLine(item);
                    break;
                case 4:
                    Console.WriteLine("Enter ID");
                    int.TryParse(Console.ReadLine(), out id);
                    dependency = s_dal.Dependency!.Read(id);
                    Console.WriteLine(dependency);
                    Console.WriteLine("Enter dependency details : dependent task, depends on task");
                    input = Console.ReadLine();
                    dependentTask = (input == "") ? dependency!.DependentTask : Convert.ToInt32(input);
                    input = Console.ReadLine();
                    dependsOnTask = (input == "") ? dependency!.DependsOnTask : Convert.ToInt32(input);
                    dependency = new Dependency(id, dependentTask, dependsOnTask);
                    s_dal.Dependency.Update(dependency);
                    break;
                case 5:
                    Console.WriteLine("Enter ID");
                    int.TryParse(Console.ReadLine(), out id);
                    s_dal.Dependency.Delete(id);
                    break;
            }
        }

    }
}