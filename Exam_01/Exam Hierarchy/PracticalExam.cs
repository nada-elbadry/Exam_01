using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_01.Exam_Hierarchy
{
    internal sealed class PracticalExam : Exam
    {
        #region Constructor
        internal PracticalExam(int durationMinutes) : base(durationMinutes) { }
        #endregion

        #region  Methods
        public override void ShowExam()
        {
            int obtained;
            ConductExamAndGrade(out obtained);

            Utilities.PrintHeader("--- Practical Review (Right Answers) ---");
            foreach (var q in Questions)
            {
                var right = q.Answers.FirstOrDefault(a => a.Id == q.RightAnswerId);
                Console.WriteLine($"{q.Header} -> Right Answer: {right?.Text}");
            }
            Utilities.WaitForKey();
        }
        #endregion

    }
}
