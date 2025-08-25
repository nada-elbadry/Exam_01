using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_01.Answer_Question_Hierarchy
{
    internal class Answer : ICloneable
    {
        #region  Properties
        public int Id { get; }
        public string Text { get; }
        #endregion

        #region  Constructors
        public Answer(int id, string text)
        {
            Id = id;
            Text = text ?? string.Empty;
        }

        #endregion

        #region  Methods
        public object Clone() => new Answer(Id, Text);
        //
        public override string ToString() => $"{Id}) {Text}"; 

        #endregion


    }
}
