namespace Exam_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Utilities.PrintHeader("=== Examination System (Basics & OOP) ===");

            int sid = ReadInt("Enter Subject Id: ");
            Console.Write("Enter Subject Name: ");
            string? sname = Console.ReadLine();

            var subject = new Subject(sid, sname ?? "Untitled");
            Utilities.PrintSuccess("Subject created successfully!");

            subject.CreateExamInteractively();

            Utilities.PrintHeader("=== Start Exam ===");
            subject.Exam?.ShowExam();

            Utilities.WaitForKey("Press any key to exit...");

            static int ReadInt(string prompt)
            {
                while (true)
                {
                    Console.Write(prompt);
                    if (int.TryParse(Console.ReadLine(), out var v)) return v;
                    Utilities.PrintError("Invalid number, try again.");
                }
            }
        }
    }
}
