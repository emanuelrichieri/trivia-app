using System;
namespace TdP2019TPFinalRichieri.DAL
{
    using Entities;
    using System.Collections.Generic;

    public interface IQuestionRepository : IRepository<Question>
    {
        IEnumerable<Question> GetQuestions(Category pCategory, Level pLevel, int pQuantity);
    }
}
