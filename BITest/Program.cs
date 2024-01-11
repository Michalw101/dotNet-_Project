using DalApi;
using DalTest;
using DO;

namespace BITest
{
    internal class Program
    {
        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Would you like to create Initial data? (Y/N)");
                string? ans = Console.ReadLine() ?? throw new FormatException("Wrong input");
                if (ans == "Y")
                    DalTest.Initialization.Do();
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
            double cost;
            int.TryParse(Console.ReadLine(), out int choice);
            string? name, email, input;
            BO.Engineer? engineer;
            BO.Task? task;
                ;
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
                    //engineer = new (id,name,email,level,cost,task);
                    //s_bl.Engineer.Create(engineer);
                    break;
                case 2:
                    Console.WriteLine("Enter ID");
                    int.TryParse(Console.ReadLine(), out id);
                    Console.WriteLine(s_bl.Engineer.Read(id));
                    break;
                case 3:
                    List<BO.Engineer?> list = s_bl.Engineer.ReadAll().ToList();
                    foreach (var item in list)
                        Console.WriteLine(item);
                    break;
                case 4:
                    Console.WriteLine("Enter ID");
                    int.TryParse(Console.ReadLine(), out id);
                    engineer = s_bl.Engineer.Read(id);
                    Console.WriteLine(engineer);
                    Console.WriteLine("Enter engineer details : id, name, email, level (0 - rookie, 1 - junior, 2 - expert), cost");
                    input = Console.ReadLine();
                    id = (input == "") ? engineer!.Id : Convert.ToInt32(input);
                    input = Console.ReadLine();
                    name = (input == "") ? engineer!.Name : input;
                    input = Console.ReadLine();
                    email = (input == "") ? engineer!.Email : input;
                    input = Console.ReadLine();
                    //level = (input == "") ? engineer!.Level : (EngineerExperience)Convert.ToInt32(input);
                    //input = Console.ReadLine();
                    //cost = (input == "") ? engineer!.Cost : Convert.ToDouble(input);
                    //engineer = new Engineer(id, name!, email!, level, cost);
                    //s_bl.Engineer.Update(engineer);
                    break;
                case 5:
                    Console.WriteLine("Enter ID");
                    int.TryParse(Console.ReadLine(), out id);
                    s_bl.Engineer.Delete(id);

                    break;
            }
        }

        private static void TaskMethods() //task menu
        {
            Console.WriteLine("Enter your choice: \n 0- Exit \n 1- Create \n 2- Read \n 3- ReadAll \n 4- Update \n 5- Delete");
            int id;
            int? engineerId;
            DateTime createdAt;
            DateTime? startDate, deadLine;
            int.TryParse(Console.ReadLine(), out int choice);
            string description;
            string? alias, remarks, deliverables, input;
            bool isMilestone;
            TimeSpan? requiredEffortTime;
            BO.Task? task;
            EngineerExperience? complexityLevel;
            switch (choice)
            {
                case 0:
                    System.Environment.Exit(0);
                    break;
                case 1:
                    Console.WriteLine("Enter task details : alias, description, is milestone");
                    alias = Console.ReadLine();
                    description = Console.ReadLine()!;
                    createdAt = DateTime.Now;
                    isMilestone = Convert.ToBoolean(Console.ReadLine());
                    //task = new (0, alias!, description, isMilestone, createdAt);
                    //s_bl.Task.Create(task);
                    break;
                case 2:
                    Console.WriteLine("Enter ID");
                    int.TryParse(Console.ReadLine(), out id);
                    Console.WriteLine(s_bl.Task.Read(id));
                    break;
                case 3:
                    List<BO.Task?> list = s_bl.Task.ReadAll().ToList();
                    foreach (var item in list)
                        Console.WriteLine(item);
                    break;
                case 4:
                    Console.WriteLine("Enter ID");
                    int.TryParse(Console.ReadLine(), out id);
                    task = s_bl.Task.Read(id);
                    Console.WriteLine(task);
                    Console.WriteLine("Enter task details : alias, description, is milestone, forecastDate, Engineer Id, complexityLevel(0 - rookie, 1 - junior, 2 - expert), required effort time, start date, dead line date, remarks, deliverables");
                    input = Console.ReadLine();
                    alias = (input == "") ? task!.Alias : input;
                    input = Console.ReadLine();
                    description = (input == "") ? task!.Description : input!;
                    //input = Console.ReadLine();
                    //isMilestone = (input == "") ? task!.isMileStone : Convert.ToBoolean(input);
                    //input = Console.ReadLine();
                    //engineerId = (input == "") ? task!.EngineerId : Convert.ToInt32(input);
                    //input = Console.ReadLine();
                    //complexityLevel = (input == "") ? task!.ComplexityLevel : (EngineerExperience)Convert.ToInt32(input);
                    //input = Console.ReadLine();
                    //requiredEffortTime = (input == "") ? task!.RequiredEffortTime : TimeSpan.FromDays(Convert.ToInt32(input));
                    input = Console.ReadLine();
                    startDate = (input == "") ? task!.StartDate : Convert.ToDateTime(input);
                    input = Console.ReadLine();
                    deadLine = (input == "") ? task!.DeadlineDate : Convert.ToDateTime(input);
                    input = Console.ReadLine();
                    remarks = (input == "") ? task!.Remarks : input;
                    input = Console.ReadLine();
                    deliverables = (input == "") ? task!.Deliverables : input;
                    //task = new DO.Task(id, alias!, description, isMilestone, task!.CreatedAtDate, engineerId, complexityLevel, requiredEffortTime, startDate, task!.ScheduledDate, deadLine, remarks, task!.CompleteDate, deliverables);
                    //s_bl.Task.Update(task);
                    break;
                case 5:
                    Console.WriteLine("Enter ID");
                    int.TryParse(Console.ReadLine(), out id);
                    s_bl.Task.Delete(id);
                    break;
            }
        }

    }
}