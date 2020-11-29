using System;
using System.Collections.Generic;
using System.Linq;

namespace TdP2019TPFinalRichieri.DAL.EntityFramework
{
    using System.Data.Entity;
    using Entities;

    public class SessionRepository : Repository<Session, DbContext>, ISessionRepository
    {
        public SessionRepository(DbContext pDbContext) : base(pDbContext)
        {
        }


        Session IRepository<Session>.Get(int pId)
        {
            return _dbContext.Set<Session>()
                            .Where(s => s.Id == pId)
                            .Include(s => s.Category)
                            .Include(s => s.Category.QuestionsSet)
                            .Include(s => s.Level)
                            .Include(s => s.User)
                            .First();
        }

        IEnumerable<Session> ISessionRepository.GetByQuestionsSet(int pQuestionsSetId)
        {
            return _dbContext.Set<Session>()
                                .Include(s => s.Category)
                                .Include(s => s.Category.QuestionsSet)
                                .Where(session => pQuestionsSetId == session.Category.QuestionsSet.Id)
                                .Include(s => s.Level)
                                .Include(s => s.User);
        }
    }
}
