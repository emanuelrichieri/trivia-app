using System;
using System.Collections.Generic;
using System.Linq;

namespace TdP2019TPFinalRichieri.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Level Level { get; set; }
        public Category Category { get; set; }
        public DateTime Date { get; set; }
        public virtual IList<Question> Questions { get; set; }
        public virtual IList<SessionAnswer> Answers { get; set; }
        public double Score { get; set; }


        /// <summary>
        /// Gets the limit session time.
        /// </summary>
        /// <returns>The limit session time.</returns>
        public int GetLimitSessionTime()
        {
            int questionsSize = Questions.ToList().Count;
            return GetLimitAnswerTime() * questionsSize;
        }

        /// <summary>
        /// Get limit answer time for each question.
        /// </summary>
        /// <returns>The question answer time.</returns>
        public int GetLimitAnswerTime()
        {
            return GetQuestionsSet().ExpectedAnswerTime;
        }

        /// <summary>
        /// Get QuestionsSet associated to this Session.
        /// </summary>
        /// <returns>The questions set.</returns>
        public QuestionsSet GetQuestionsSet()
        {
            return Category.QuestionsSet;
        }


        /// <summary>
        /// Get total session time in seconds, that is the sum of each  
        /// answer time of session's answers
        /// </summary>
        public int GetTime()
        {
            return this.Answers.Sum(answer => answer.AnswerTime);
        }
    }
}
