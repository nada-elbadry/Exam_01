using Exam_01.Answer_Question_Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_01.Exam_Hierarchy
{
    internal abstract class Exam : ICloneable
    {
        #region  properties
        public int DurationMinutes { get; protected set; }
        public int QuestionCount => Questions.Count;
        public List<Question> Questions { get; protected set; } = new();
        public int TotalGrade => Questions.Sum(q => q.Mark);

        #endregion


        #region  Constructors
        protected Exam(int durationMinutes)
        {
            DurationMinutes = Math.Max(0, durationMinutes);
        }
        #endregion

        #region  Methods
        public abstract void ShowExam();

        protected int ConductExamAndGrade(out int obtained)
        {
            obtained = 0;
            var userAnswers = new Dictionary<Question, int>();

            Utilities.PrintHeader($"--- Exam Started (Duration: {DurationMinutes} min) ---");

            Questions.Sort();

            foreach (var q in Questions)
            {
                q.Display();
                int answer = q.ReadUserAnswer();
                userAnswers[q] = answer;
                if (q.IsCorrect(answer))
                    obtained += q.Mark;
                Utilities.PrintSeparator();
            }

            Console.WriteLine($"Exam Finished. Grade: {obtained}/{TotalGrade}\n");
            return obtained;
        }


        public virtual object Clone()
        {
            var clone = (Exam)MemberwiseClone();
            clone.Questions = Questions.Select(q => (Question)q.Clone()).ToList();
            return clone;
        }

        public override string ToString() => $"{GetType().Name} - Duration: {DurationMinutes} min - Questions: {QuestionCount} - Total: {TotalGrade}"; 
        #endregion
    }
}
