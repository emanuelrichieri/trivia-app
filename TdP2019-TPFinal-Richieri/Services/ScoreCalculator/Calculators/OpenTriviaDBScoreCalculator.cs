using System;
using System.Linq;
using TdP2019TPFinalRichieri.Entities;

namespace TdP2019TPFinalRichieri.Services.ScoreCalculator.Calculators
{
    public class OpenTriviaDBScoreCalculator : IScoreCalculator
    {
        private enum DifficultyFactor
        {
            HARD = 5,
            MEDIUM = 3,
            EASY = 1
        }

        /// <summary>
        /// Calculate score for OpenTriviaDB Questions Set sessions.
        /// </summary>
        /// <returns>
        ///     Correct answers count / total questions count * difficulty factor * time factor.
        /// </returns>
        /// <param name="pSession">P session.</param>
        public double CalculateScore(Session pSession)
        {
            double difficultyFactor = (double)this.GetDifficultyFactor(pSession.Level);
            int totalQuestionsCount = pSession.Questions.Count();
            double timeFactor = this.GetTimeFactor(pSession.GetTime(), totalQuestionsCount);
            int correctAnswersCount = pSession.Answers.Count(answer => answer.IsCorrect());
            return ((double)correctAnswersCount / totalQuestionsCount) * difficultyFactor * timeFactor;
        }

        /// <summary>
        /// Get Difficulty Factor for a given Level from its name.
        /// EASY = 1, MEDIUM = 3, HARD = 5
        /// </summary>
        /// <returns>The difficulty factor.</returns>
        /// <param name="pLevel">Level.</param>
        private DifficultyFactor GetDifficultyFactor(Level pLevel)
        {
            if (pLevel == null)
            {
                throw new Exception("Session Level cannot be null. ");
            }
            if (Enum.TryParse(pLevel.Name, true, out DifficultyFactor difficultyFactor))
            {
                return difficultyFactor;
            }
            throw new Exception($"There is no difficulty factor setted for level {pLevel.Name}");
        }

        /// <summary>
        /// Gets time factor for a given sessionTime and sessionQuestionsCount
        /// </summary>
        /// <returns>
        ///     The time factor.
        ///     (Session time / total questions count) lower than 5, then 5 
        ///     (Session time / total questions count) between 5 and 20, then 3
        ///     (Session time / total questions count) higher than 20, then 1
        /// </returns>
        /// <param name="pSessionTime">P time.</param>
        /// <param name="pSessionQuestionsCount">P total questions count.</param>
        private double GetTimeFactor(int pSessionTime, int pSessionQuestionsCount)
        {
            int factor = pSessionTime / pSessionQuestionsCount;
            if (factor < 5)
            {
                return 5;
            }
            if (factor < 20)
            {
                return 3;
            }
            return 1;
        }
    }
}
