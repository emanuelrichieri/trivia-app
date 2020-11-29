using System;
using System.Collections.Generic;
using System.Linq;

namespace TdP2019TPFinalRichieri.Entities
{
    public class Session : IComparable
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Level Level { get; set; }
        public Category Category { get; set; }
        public DateTime Date { get; set; }
        public virtual IList<Question> Questions { get; set; }
        public virtual IList<SessionAnswer> Answers { get; set; } = new List<SessionAnswer>();
        public double Score { get; set; }


        /// <summary>
        /// Gets the limit session time.
        /// </summary>
        /// <returns>The limit session time.</returns>
        public int GetLimitSessionTime()
        {
            int questionsSize = Questions.Count;
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


        /// <summary>
        /// Compare two sessions. First by score (higher first), and if they are equal,
        /// then by time (lower first).
        /// </summary>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (obj is Session otherSession)
            {
                const double EPSILON = 0.00000001;
                if (Math.Abs(otherSession.Score - this.Score) < EPSILON)
                {
                    return this.GetTime() - otherSession.GetTime();
                }
                return -this.Score.CompareTo(otherSession.Score);
            }
            throw new ArgumentException("Object is not a Session");
        }
    }
}
