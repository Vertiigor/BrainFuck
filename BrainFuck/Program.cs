using BrainfuckInterpreter;
using System.Diagnostics;

namespace BrainFuck
{
    public delegate void Message(string msg);
    internal class Program
    {
        static void ShowHelp(Message message)
        {
            Console.ForegroundColor= ConsoleColor.Blue;
            message?.Invoke("\n'.'\t\tPrint the byte of memory pointed to by the pointer, converting to a character according to ASCII.\n" +
                "'+'\t\tIncrement the byte of memory pointed to by the pointer.\n" +
                "'-'\t\tDecrement the byte of memory pointed to by the pointer.\n" +
                "','\t\tEnter a character and store its ASCII code in the byte of memory pointed to by the pointer.\n" +
                "'>'\t\tShift memory pointer right by 1 byte.\n" +
                "'<'\t\tShift memory pointer left by 1 byte.\n" +
                "'a - z, 0 - 9'\tStore the ASCII code of this character in the byte of memory pointed to by the pointer.\n" +
                "'['\t\tIf the value of the current cell is zero, move forward in the program text to the character following the corresponding ] (including nesting).\n" +
                "']'\t\tIf the value of the current cell is not zero, go back through the program text to the character [ (taking into account nesting).\n" +
                "'help'\t\tShows a list of commands and their definition.\n" +
                "'exit'\t\tExits program.");
        }
        public static void Main()
        {
            Stopwatch stopwatch= new Stopwatch();

            string input = string.Empty;

            Message message = new Message(Console.WriteLine);

            message?.Invoke("To get info about commands enter 'help'.\n");

            while (input != "exit")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("$ ");
                Console.ForegroundColor = ConsoleColor.White;

                input = Console.ReadLine();

                switch (input)
                {
                    case "help":
                        ShowHelp(message);
                        break;

                    case "clear":
                        Console.Clear();
                        break;

                    case "exit":
                        break;

                    default:
                        stopwatch.Restart();
                        Brainfuck.Run(input, Console.Read, Console.Write);
                        stopwatch.Stop();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\n\nDone in:\t{stopwatch.ElapsedMilliseconds} milliseconds");

                        break;
                }
                Console.WriteLine();
            }
        }
    }
}