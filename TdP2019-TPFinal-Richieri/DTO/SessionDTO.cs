using System;
using System.Collections.Generic;
namespace TdP2019TPFinalRichieri.DTO
{
    public class SessionDTO
    {
        public int Id { get; set; }
        public IList<QuestionDTO> Questions { get; set; }
        public IList<SessionAnswerDTO> Answers { get; set; }
        public string Category { get; set; }
        public string Level { get; set; }
        public string Username { get; set; }
        public string QuestionsSet { get; set; }
        public DateTime Date { get; set; }
        public int LimitAnswerTime { get; set; }
        public int LimitSessionTime { get; set; }
        public IList<QuestionDTO> RemainingQuestions { get; set; }

    }
}
