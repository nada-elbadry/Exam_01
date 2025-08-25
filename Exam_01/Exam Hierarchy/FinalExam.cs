using Exam_01.Answer_Question_Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_01.Exam_Hierarchy
{
    internal sealed class FinalExam : Exam
    {
        #region Constructor
        internal FinalExam(int durationMinutes) : base(durationMinutes) { }
        #endregion


        #region  Methods

        public override void ShowExam()
        {
            int obtained;
            var userAnswers = new Dictionary<Question, int>();
            Utilities.PrintHeader($"--- Final Exam Started (Duration: {DurationMinutes} min) ---");

            Questions.Sort();

            foreach (var q in Questions)
            {
                q.Display();
                int ans = q.ReadUserAnswer();
                userAnswers[q] = ans;
                Utilities.PrintSeparator();
            }

            obtained = 0;
            Utilities.PrintHeader("--- Final Exam Review ---");
            foreach (var q in Questions)
            {
                var right = q.Answers.First(a => a.Id == q.RightAnswerId);
                var user = userAnswers[q];
                bool correct = q.IsCorrect(user);
                int earned = correct ? q.Mark : 0;
                obtained += earned;

                var userText = q.Answers.FirstOrDefault(a => a.Id == user)?.Text ?? "N/A";
                Console.WriteLine($"Q: {q.Header} [{q.Mark}]");
                Console.WriteLine($"   Your Answer: {userText}");
                Console.WriteLine($"   Right Answer: {right.Text}");
                Console.WriteLine($"   Earned: {earned}\n");
            }

            Console.WriteLine($"Total Grade: {obtained}/{TotalGrade}\n");
            Utilities.WaitForKey();
        }
        #endregion
    }
}
