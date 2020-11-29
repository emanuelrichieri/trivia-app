using System;
namespace TdP2019TPFinalRichieri.DAL
{
    using System.Collections.Generic;
    using Entities;
    public interface ISessionRepository : IRepository<Session>
    {
        IEnumerable<Session> GetByQuestionsSet(int pQuestionsSetId);
    }
}
