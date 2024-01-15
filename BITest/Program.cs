using BO;

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
                    Console.WriteLine("Enter your choice: \n 0- Exit \n 1- Engineers \n 2- Tasks \n 3- Create schedule");
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
                Console.WriteLine(e.Message);
            }
        }


        /// <summary>
        /// Function that resposible to activate the engineer's functions such as read and so on.
        /// </summary>
        /// <exception cref="BlNullPropertyException"></exception>
        /// <exception cref="BlUnvalidException"></exception>
        private static void EngineerMethods() // engineer manu
        {
            Console.WriteLine("Enter your choice: \n 0- Exit \n 1- Create \n 2- Read \n 3- ReadAll \n 4- Update \n 5- Delete");
            int.TryParse(Console.ReadLine(), out int choice);
            int _id, _level;
            string _name, _email;
            double _cost;
            BO.Engineer? engineer;
            switch (choice)
            {
                case 0:
                    System.Environment.Exit(0);
                    break;
                case 1:
                    Console.WriteLine("Enter engineer's details:");
                    Console.WriteLine("Enter engineer's ID:");
                    _id = int.Parse(Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter an id"));
                    Console.WriteLine("Enter engineer's name:");
                    _name = (Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter a name"));
                    Console.WriteLine("Enter engineer's email:");
                    _email = (Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter an email"));
                    Console.WriteLine("Enter engineer's level { 0-Beginner, 1-AdvancedBeginner, 2-Intermediate, 3-Advanced, 4-Expert }:");
                    _level = int.Parse(Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter a level"));
                    Console.WriteLine("Enter engineer's cost:");
                    _cost = double.Parse(Console.ReadLine()!);
                    engineer = new BO.Engineer()
                    {
                        Id = _id,
                        Name = _name,
                        Email = _email,
                        Level = (BO.EngineerExperience)_level,
                        Cost = _cost
                    };
                    s_bl.Engineer.Create(engineer);
                    Console.WriteLine("Created successfully");
                    break;
                case 2:
                    Console.WriteLine("Enter ID");
                    _id = int.Parse(Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter an id"));
                    engineer = s_bl.Engineer?.Read(_id);
                    Console.WriteLine(engineer);
                    break;
                case 3:
                    List<BO.Engineer?> list = s_bl.Engineer.ReadAll().ToList();
                    foreach (var item in list)
                        Console.WriteLine(item);
                    break;
                case 4:
                    Console.WriteLine("Enter ID");
                    int.TryParse(Console.ReadLine(), out _id);
                    //_id = int.Parse(Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter an id"));
                    Console.WriteLine("Enter engineer's name:");
                    _name = (Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter a name"));
                    Console.WriteLine("Enter engineer's email:");
                    _email = (Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter an email"));
                    Console.WriteLine("Enter engineer's level { 0-Beginner, 1-AdvancedBeginner, 2-Intermediate, 3-Advanced, 4-Expert }:");
                    _level = int.Parse(Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter a level"));
                    Console.WriteLine("Enter engineer's cost:");
                    _cost = double.Parse(Console.ReadLine()!);
                    engineer = new BO.Engineer()
                    {
                        Id = _id,
                        Name = _name,
                        Email = _email,
                        Level = (BO.EngineerExperience)_level,
                        Cost = _cost
                    };
                    s_bl.Engineer.Update(engineer);
                    Console.WriteLine("successfully updated");
                    break;
                case 5:
                    Console.WriteLine("Enter ID");
                    _id = int.Parse(Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter an id"));
                    s_bl.Engineer.Delete(_id);
                    Console.WriteLine("Deleted successfully");
                    break;
                default:
                    throw new BlUnvalidException("Your choice is invalid");
            }
        }

        /// <summary>
        /// Function that resposible to activate the task's functions such as read and so on.
        /// </summary>
        /// <exception cref="BlNullPropertyException"></exception>
        /// <exception cref="BlUnvalidException"></exception>
        private static void TaskMethods() //task menu
        {
            Console.WriteLine("Enter your choice: \n 0- Exit \n 1- Create \n 2- Read \n 3- ReadAll \n 4- Update \n 5- Delete");
            int.TryParse(Console.ReadLine(), out int choice);
            int _engineerId, _complexityLevel, _id;
            string _description, _alias, _product, _remarks;
            DateTime _createdAtDate, _startDate, _forecastDate, _completeDate, _deadlineDate, _scheduledStartDate;
            TimeSpan _requiredEffortTime;
            BO.Task? task;
            switch (choice)
            {
                case 0:
                    System.Environment.Exit(0);
                    break;
                case 1:
                    Console.WriteLine("Enter task's details:");
                    Console.WriteLine("Enter task's description:");
                    _description = (Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter a description"));
                    Console.WriteLine("Enter task's alias:");
                    _alias = (Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter an alias"));
                    Console.WriteLine("Enter task's create date:");
                    _createdAtDate = Convert.ToDateTime(Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter scheduled start date"));
                    Console.WriteLine("Enter task's scheduled start date:");
                    _scheduledStartDate = Convert.ToDateTime(Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter create date"));
                    Console.WriteLine("Enter the amount of time required to perform the task");
                    _requiredEffortTime = new TimeSpan(int.Parse(Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter required effort time")));
                    Console.WriteLine("Enter task's start date:");
                    _startDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter task's scheduled date:");
                    _forecastDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter task's deadline date:");
                    _deadlineDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter task's complete date:");
                    _completeDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter task's product:");
                    _product = Console.ReadLine()!;
                    Console.WriteLine("Enter task's remarks:");
                    _remarks = Console.ReadLine()!;
                    Console.WriteLine("Enter engineer id:");
                    _engineerId = int.Parse(Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter an engineer id"));
                    Console.WriteLine("Enter task's complexity level:");
                    _complexityLevel = int.Parse(Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter a complexity level"));
                    //task = new BO.Task()
                    //{
                    //    Id = 0,
                    //    Alias = _alias,
                    //    Description = _description,
                    //    CreatedAtDate = _createdAtDate,
                    //    Status = 0,
                    //    //dependencies
                    //    //milestone
                    //    ScheduledStartDate = _scheduledStartDate,
                    //    RequiredEffortTime = _requiredEffortTime,
                    //    StartDate = _startDate,
                    //    ForecastDate = _forecastDate,
                    //    DeadlineDate = _deadlineDate,
                    //    CompleteDate = _completeDate,
                    //    Product = _product,
                    //    Remarks = _remarks,
                    //    //engineer
                    //    ComplexityLevel = (BO.EngineerExperience)_complexityLevel,
                    //};
                    //s_bl.Task?.Create(task);
                    Console.WriteLine("Created successfully");
                    break;
                case 2:
                    Console.WriteLine("Enter ID");
                    int.TryParse(Console.ReadLine(), out _id);
                    Console.WriteLine(s_bl.Task.Read(_id));
                    break;
                case 3:
                    List<BO.Task?> list = s_bl.Task.ReadAll().ToList();
                    foreach (var item in list)
                        Console.WriteLine(item);
                    break;
                case 4:
                    Console.WriteLine("Enter task's details:");
                    Console.WriteLine("Enter task's description:");
                    _description = (Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter a description"));
                    Console.WriteLine("Enter task's alias:");
                    _alias = (Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter an alias"));
                    Console.WriteLine("Enter task's create date:");
                    _createdAtDate = Convert.ToDateTime(Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter scheduled start date"));
                    Console.WriteLine("Enter task's scheduled start date:");
                    _scheduledStartDate = Convert.ToDateTime(Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter create date"));
                    Console.WriteLine("Enter the amount of time required to perform the task");
                    _requiredEffortTime = new TimeSpan(int.Parse(Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter required effort time")));
                    Console.WriteLine("Enter task's start date:");
                    _startDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter task's scheduled date:");
                    _forecastDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter task's deadline date:");
                    _deadlineDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter task's complete date:");
                    _completeDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Enter task's product:");
                    _product = Console.ReadLine()!;
                    Console.WriteLine("Enter task's remarks:");
                    _remarks = Console.ReadLine()!;
                    Console.WriteLine("Enter engineer id:");
                    _engineerId = int.Parse(Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter an engineer id"));
                    Console.WriteLine("Enter task's complexity level:");
                    _complexityLevel = int.Parse(Console.ReadLine() ?? throw new BlNullPropertyException("You did not enter a complexity level"));
                    //task = new BO.Task()
                    //{
                    //    Id = 0,
                    //    Alias = _alias,
                    //    Description = _description,
                    //    CreatedAtDate = _createdAtDate,
                    //    Status = 0,
                    //    //dependencies
                    //    //milstone
                    //    ScheduledStartDate = _scheduledStartDate,
                    //    RequiredEffortTime = _requiredEffortTime,
                    //    StartDate = _startDate,
                    //    ForecastDate = _forecastDate,
                    //    DeadlineDate = _deadlineDate,
                    //    CompleteDate = _completeDate,
                    //    Product = _product,
                    //    Remarks = _remarks,
                    //    //engineer
                    //    ComplexityLevel = (BO.EngineerExperience)_complexityLevel,
                    //};
                    //s_bl.Task.Update(task);
                    Console.WriteLine("successfully updated");
                    break;
                case 5:
                    Console.WriteLine("Enter ID");
                    int.TryParse(Console.ReadLine(), out _id);
                    s_bl.Task.Delete(_id);
                    Console.WriteLine("Deleted successfully");
                    break;
                default:
                    throw new BlNullPropertyException("your choice is invalid");
            }
        }
    }  
}







