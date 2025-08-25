using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_01.Answer_Question_Hierarchy
{
    internal sealed class MCQQuestion : Question
    {
        #region  Constructor
        internal MCQQuestion(string header, string body, int mark, IEnumerable<string> options, int rightIndex1Based)
         : base(header, body, mark)
        {

            int i = 1;
            Answers = options?.Select(opt => new Answer(i++, opt ?? string.Empty)).ToList() ?? new List<Answer>();

            RightAnswerId = (rightIndex1Based >= 1 && rightIndex1Based <= Answers.Count) ? rightIndex1Based : 1;
        }

        #endregion

        #region   Methods
        public override int ReadUserAnswer()
        {
            var validIds = Answers.Select(a => a.Id).ToHashSet();
            while (true)
            {
                Console.Write($"Enter answer id ({string.Join("/", validIds)}): ");
                if (int.TryParse(Console.ReadLine(), out int id) && validIds.Contains(id))
                    return id;
                Utilities.PrintError("Invalid choice, try again.");
            }
        }
        #endregion
    }
}
