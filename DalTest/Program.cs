using Dal;
using DalApi;
using DO;
using System.ComponentModel.DataAnnotations;

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
            int id, cost;
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
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter ID");
                    id = Convert.ToInt32(Console.ReadLine());
                    engineer = s_dalEngineer!.Read(id);
                    Console.WriteLine(engineer);
                    Console.WriteLine("Enter engineer details : id, name, email, level (0 - rookie, 1 - junior, 2 - expert), cost");
                    input = Console.ReadLine();
                    id = (input == "''") ? engineer!.Id : Convert.ToInt32(input);
                    name = Console.ReadLine() ?? engineer!.Name;
                    email = Console.ReadLine() ?? engineer!.Email;
                    level = (EngineerExperience)Convert.ToInt32(Console.ReadLine() ?? Convert.ToInt32(engineer!.Level).ToString());
                    cost = Convert.ToInt32(Console.ReadLine() ?? engineer!.Cost.ToString());
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