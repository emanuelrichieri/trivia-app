using System;
using System.Collections.Generic;

namespace TdP2019TPFinalRichieri.DTO
{
    public class AnswerResultDTO
    {
        public bool IsCorrect { get; set; }
        public string Question { get; set; }
        public IList<AnswerDTO> CorrectAnswers { get; set; }
        public IList<AnswerDTO> UserAnswers { get; set; }
    }
}
