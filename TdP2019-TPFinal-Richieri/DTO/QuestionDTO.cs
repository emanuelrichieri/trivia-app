using System;
using System.Collections.Generic;

namespace TdP2019TPFinalRichieri.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public bool IsMultiple { get; set; }
        public LevelDTO Level { get; set; }
        public CategoryDTO Category { get; set; }
        public IList<AnswerDTO> CorrectAnswers { get; set; }
        public IList<AnswerDTO> IncorrectAnswers { get; set; }
        public DateTime ShowedMoment { get; set; }
    }
}
