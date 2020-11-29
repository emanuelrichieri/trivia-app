using System;
using System.Linq;
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


        /// <summary>
        /// Get all answers with random order
        /// </summary>
        public IList<AnswerDTO> GetAnswers()
        {
            List<AnswerDTO> answers = new List<AnswerDTO>();
            answers = answers.Concat(this.CorrectAnswers).ToList();
            answers = answers.Concat(this.IncorrectAnswers).ToList();
            var rand = new Random();
            answers.Sort((x, y) => rand.Next() - rand.Next());

            return answers;
        }
    }
}
