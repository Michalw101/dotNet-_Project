using System;

namespace Stage0
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome0063();
            Welcome9415();
            Console.ReadKey();
        }

        static partial void Welcome9415();
        private static void Welcome0063()
        {
            Console.Write("Enter your name: ");
            string? userName = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my firt console application", userName);
        }
    }
}
