using Exam_01.Answer_Question_Hierarchy;
using Exam_01.Exam_Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_01
{
    internal class Subject
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public Exam? Exam { get; private set; }

        public Subject(int id, string name)
        {
            Id = id;
            Name = name ?? string.Empty;
        }

        public void CreateExamInteractively()
        {
            Utilities.PrintHeader($"Create Exam for Subject: {Name} (Id={Id})");
            int duration = ReadInt("Enter duration in minutes: ", min: 0);

            Console.Write("Enter exam type (Final/Practical): ");
            Exam = ReadExamType(Console.ReadLine(), duration);

            int qCount = ReadInt("Enter number of questions: ", min: 1);
            for (int i = 1; i <= qCount; i++)
            {
                Utilities.PrintHeader($"-- Create Question #{i} --");
                Console.Write("Type (TF/MCQ): ");
                string? type = Console.ReadLine();

                string header = ReadNonEmpty("Header: ", toUpper: true);
                string body = ReadNonEmpty("Body: ");
                int mark = ReadInt("Mark (>=0): ", min: 0);

                if (string.Equals(type, "TF", StringComparison.OrdinalIgnoreCase))
                {
                    bool rightIsTrue = ReadBool("Right answer is True? (y/n): ");
                    Exam!.Questions.Add(new TFQuestion(header, body, mark, rightIsTrue));
                }
                else
                {
                    int optCount = ReadInt("How many options? (>=2): ", min: 2);
                    var options = new List<string>();
                    for (int j = 1; j <= optCount; j++)
                        options.Add(ReadNonEmpty($"Option {j}: "));

                    int right = ReadInt($"Right option id (1..{optCount}): ", 1, optCount);
                    Exam!.Questions.Add(new MCQQuestion(header, body, mark, options, right));
                }
            }

            Utilities.PrintSuccess("Exam created successfully!");
            Console.WriteLine(Exam);
            Utilities.WaitForKey();
        }

        private static Exam ReadExamType(string? input, int duration)
        {
            while (true)
            {
                if (string.Equals(input, "Final", StringComparison.OrdinalIgnoreCase))
                    return new FinalExam(duration);
                if (string.Equals(input, "Practical", StringComparison.OrdinalIgnoreCase))
                    return new PracticalExam(duration);

                Utilities.PrintError("Invalid type. Enter (Final/Practical): ");
                input = Console.ReadLine();
            }
        }

        private static int ReadInt(string prompt, int? min = null, int? max = null)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int v)
                    && (!min.HasValue || v >= min)
                    && (!max.HasValue || v <= max)
                    && v != 0)
                    return v;

                Utilities.PrintError("Invalid number, try again.");
            }
        }

        private static string ReadNonEmpty(string prompt, bool toUpper = false, bool toLower = false)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(s))
                {
                    s = s.Trim();
                    if (toUpper) s = s.ToUpperInvariant();
                    if (toLower) s = s.ToLowerInvariant();
                    return s;
                }

                Utilities.PrintError("Value cannot be empty.");
            }
        }

        private static bool ReadBool(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
                if (s is "y" or "yes" or "true") return true;
                if (s is "n" or "no" or "false") return false;
                Utilities.PrintError("Enter y/n.");
            }
        }

        public override string ToString() => $"Subject(Id={Id}, Name={Name}, Exam={(Exam is null ? "None" : Exam.GetType().Name)})";
    }
}
