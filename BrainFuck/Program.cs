using BrainfuckInterpreter;
using NUnitLite;

namespace BrainFuck
{
    internal class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.Write("$ ");
                Brainfuck.Run(Console.ReadLine(), Console.Read, Console.Write);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}