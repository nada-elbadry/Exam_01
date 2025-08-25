using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_01
{
    internal class Utilities
    {
        public static void PrintHeader(string text)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=======================================");
            Console.WriteLine($"   {text}");
            Console.WriteLine("=======================================");
            Console.ResetColor();
        }

        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"❌ {message}");
            Console.ResetColor();
        }

        public static void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✔ {message}");
            Console.ResetColor();
        }

        public static void PrintSeparator()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("---------------------------------------");
            Console.ResetColor();
        }

        public static void WaitForKey(string message = "Press any key to continue...")
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.ReadKey();
        }

        public static void PrintQuestion(string header, string body, int mark)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n[Q] {header} ({mark} mark)");
            Console.ResetColor();
            Console.WriteLine(body);
        }

        public static void PrintAnswer(int id, string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"{id}) {text}");
            Console.ResetColor();
        }
    }
}
