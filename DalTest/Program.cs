using Dal;
using DalApi;
using System.Runtime.CompilerServices;

namespace DalTest
{
    internal class Program
    {
        private static IEngineer? s_dalEngineer = new EngineerImplementation();
        private static ITask? s_dalTask = new TaskImplementation();
        private static IDependency? s_dalDependency = new DependencyImplementation();


        static void Main(string[] args)
        {
            try
            {
                Initialization.DO(s_dalEngineer, s_dalTask, s_dalDependency);
                Console.WriteLine("Enter your choice: /n 0- Exit /n 1- Engineers /n 2- Tasks /n 3- Dependencies ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        System.Environment.Exit(0);
                        break;
                    case 1:
                        Console.WriteLine("Enter your choice: /n 0- Exit /n 1- Create /n 2- Read /n 3- ReadAll /n 4- Update /n 5- Delete");
                        choice = Convert.ToInt32(Console.ReadLine());
                        switch(choice)
                        {
                            case 0:
                                System.Environment.Exit(0);
                                break;
                            case 1:
                                Initialization.createEngineers();                                break;
                        }




                        break;

                    default:
                        break;

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}