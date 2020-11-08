using System;

namespace TdP2019TPFinalRichieri.DAL.EntityFramework
{
    using System.Data.Entity;
    using Entities;

    public class LevelRepository : Repository<Level, DbContext>, ILevelRepository
    {
        public LevelRepository(DbContext pDbContext) : base(pDbContext)
        {
        }
    }
}
