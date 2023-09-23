using System;
namespace stage0
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome9415();
        }

        static partial void Welcome0063();
        private static void Welcome9415()
        {
            Console.Write("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("{0}, welocme to my first console application", name);
        }
    }
}