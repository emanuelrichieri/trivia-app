using System;
using System.Collections.Generic;

namespace TdP2019TPFinalRichieri.DTO
{
    public class SessionAnswerDTO
    {
        public SessionDTO Session { get; set; }
        public QuestionDTO Question { get; set; }
        public IList<AnswerDTO> Answers { get; set; }
        public int AnswerTime { get; set; }
    }
}
