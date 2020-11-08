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
        ///     - Difficulty factor: EASY = 1, MEDIUM = 3, HARD = 5.
        ///     - Time factor: Session time / total questions count
        /// </returns>
        /// <param name="pSession">P session.</param>
        public double CalculateScore(Session pSession)
        {
            double difficultyFactor = (double) this.GetDifficultyFactor(pSession.Level);
            int totalQuestionsCount = pSession.Questions.Count();
            double timeFactor = pSession.GetTime() / totalQuestionsCount;
            int correctAnswersCount = pSession.Answers.Count(answer => answer.IsCorrect());
            return correctAnswersCount / totalQuestionsCount * difficultyFactor * timeFactor;
        }

        /// <summary>
        /// Get Difficulty Factor for a given Level from its name.
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
    }
}
