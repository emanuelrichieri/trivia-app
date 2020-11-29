using System;
using System.Linq;
using System.Collections.Generic;

namespace TdP2019TPFinalRichieri.DTO
{
    public class AnswerResultDTO
    {
        public bool IsCorrect { get; set; }
        public string Question { get; set; }
        public IList<AnswerDTO> CorrectAnswers { get; set; }
        public IList<AnswerDTO> UserAnswers { get; set; }

        /// <summary>
        /// Get correct answers in string format.
        /// </summary>
        public string GetCorrectAnswers()
        {
            return string.Join(", ", CorrectAnswers.Select(answer => answer.Answer));
        }
    }
}
