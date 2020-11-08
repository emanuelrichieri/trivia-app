namespace TdP2019TPFinalRichieri.DAL.EntityFramework
{
    using Entities;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Exceptions;
    using System.Data.Entity;

    public class QuestionRepository : Repository<Question, DbContext>, IQuestionRepository
    {
    
        public QuestionRepository(DbContext pDbContext) : base(pDbContext)
        {
        }

        /// <summary>
        /// Get <paramref name="pQuantity"/> random questions 
        /// from the given category and level.
        /// </summary>
        /// <returns>The questions.</returns>
        /// <param name="pCategory">Category.</param>
        /// <param name="pLevel">Level.</param>
        /// <param name="pQuantity">Questions.</param>
        public IEnumerable<Question> GetQuestions(Category pCategory, Level pLevel, int pQuantity)
        {
            IEnumerable<Question> questions = new List<Question>();
            if (pCategory == null || pLevel == null)
            {
                throw new InvalidParametersException("Level and Category must not be null.");
            }
            if (pQuantity <= 0)
            {
                throw new InvalidParametersException("Quantity must be greather than zero.");
            }
            var rand = new Random();
            questions = this.GetWhere(bQuestion => Equals(bQuestion.Category.Id, pCategory.Id) 
                                             && Equals(bQuestion.Level.Id, pLevel.Id))
                                                .OrderBy(x => rand.Next())
                                                .Take(pQuantity);
            if (questions.Count() < pQuantity)
            {
                throw new NotEnoughQuestionsException($"There are {questions.Count()} questions with the given parameters.");
            }

            return questions;
        }
    }
}