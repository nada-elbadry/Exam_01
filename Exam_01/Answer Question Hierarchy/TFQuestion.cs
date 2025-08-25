using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_01.Answer_Question_Hierarchy
{
    internal sealed class TFQuestion : Question
    {
        #region   Constructor
        internal TFQuestion(string header, string body, int mark, bool rightIsTrue) : base(header, body, mark)

        {

            Answers = new List<Answer>
            {
                new Answer(1, "True"),
                new Answer(2, "False")
            };
            RightAnswerId = rightIsTrue ? 1 : 2;
        }
        #endregion

        #region   Methods
        public override int ReadUserAnswer()
        {
            while (true)
            {
                Console.Write("Enter answer (1=True, 2=False): ");
                if (int.TryParse(Console.ReadLine(), out int id) && (id == 1 || id == 2))
                    return id;
                Utilities.PrintError("Invalid choice, try again.");
            }
        }
        #endregion
    }
}
