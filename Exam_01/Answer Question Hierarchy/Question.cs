using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_01.Answer_Question_Hierarchy
{
    internal abstract class Question : ICloneable, IComparable<Question>
    {
        #region   properties
        public string Header { get; protected set; }
        public string Body { get; protected set; }
        public int Mark { get; protected set; }
        public List<Answer> Answers { get; protected set; } = new();
        public int RightAnswerId { get; protected set; }
        #endregion

        #region  Constructor
        protected Question(string header, string body, int mark)
        {
            Header = header ?? string.Empty;
            Body = body ?? string.Empty;
            Mark = Math.Max(0, mark);
        }
        #endregion

        #region Methods
        public virtual void Display()
        {
            Utilities.PrintQuestion(Header, Body, Mark);
            foreach (var ans in Answers)
                Utilities.PrintAnswer(ans.Id, ans.Text);
        }

        public abstract int ReadUserAnswer();

        public bool IsCorrect(int userAnswerId) => userAnswerId == RightAnswerId;

        public virtual object Clone()
        {
            var copy = (Question)MemberwiseClone();
            copy.Answers = Answers.Select(a => (Answer)a.Clone()).ToList();
            return copy;
        }

        public int CompareTo(Question? other)
        {
            if (other is null) return 1;
            return string.Compare(Header, other.Header, StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString() => $"{Header} [{Mark} mark(s)]";
        #endregion
    }
}
