namespace TdP2019TPFinalRichieri.DAL.EntityFramework
{
    using System.Data.Entity;
    using Entities;

    public class QuestionsSetRepository : Repository<QuestionsSet, DbContext>, IQuestionsSetRepository
    {
        public QuestionsSetRepository(DbContext pDbContext) : base(pDbContext) { }
    }
}
