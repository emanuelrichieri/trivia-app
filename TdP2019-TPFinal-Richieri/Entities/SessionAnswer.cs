using System.Linq;
using System.Collections.Generic;
namespace TdP2019TPFinalRichieri.Entities
{
    public class SessionAnswer
    {
        public int Id { get; set; }
        public Question Question { get; set; }
        public virtual IList<Answer> Answers { get; set; }

        /// <summary>
        /// Answer time in seconds.
        /// </summary>
        public int AnswerTime { get; set; }


        /// <summary>
        /// Determines if a SessionAnswer is correct.
        /// </summary>
        /// <returns><c>true</c>, if question correct answers matches with all session answers, 
        ///         <c>false</c> otherwise.
        /// </returns>
        public bool IsCorrect()
        {
            return Answers.Count() == Question.GetCorrectAnswers().Count()
                    && Answers.All(answer => answer.IsCorrect);
        }
    }
}
