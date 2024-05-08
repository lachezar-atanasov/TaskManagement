using System;
using System.Linq;
using TaskManagement.Commands.Enums;

namespace TaskManagement.Helpers
{
    public static class Printers
    {
        public static void ColorPrint(string message)
        {

            // | in the start of each line
            string[] lines = message.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            const string rightSyntax = $"Right command syntax:";

            foreach (string line in lines)
            {
                if (line.Contains(rightSyntax))
                {
                    int index = line.IndexOf(rightSyntax, StringComparison.Ordinal);
                    string leftPart = line.Substring(0, index + rightSyntax.Length);
                    string rightPart = line.Substring(index + rightSyntax.Length);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"| {leftPart}");


                    foreach (string word in rightPart.Split(' '))
                    {
                        if (Enum.GetNames(typeof(CommandType)).ToList().Contains(word))
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(word + " ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(word + " ");
                        }
                    }

                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"| {line.Trim()}");
                }
            }
            Console.ResetColor();
        }
    }
}
