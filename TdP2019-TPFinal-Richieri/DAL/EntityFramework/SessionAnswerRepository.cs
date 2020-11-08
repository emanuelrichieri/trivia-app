using System;
namespace TdP2019TPFinalRichieri.DAL.EntityFramework
{
    using System.Data.Entity;
    using Entities;
    public class SessionAnswerRepository : Repository<SessionAnswer, DbContext>, ISessionAnswerRepository
    {
        public SessionAnswerRepository(DbContext pDbContext) : base(pDbContext) { }
    }
}
