using System;

namespace TdP2019TPFinalRichieri.DAL.EntityFramework
{
    using System.Data.Entity;
    using Entities;

    public class SessionRepository : Repository<Session, DbContext>, ISessionRepository
    {
        public SessionRepository(DbContext pDbContext) : base(pDbContext)
        {
        }
    }
}
