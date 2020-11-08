using System;

namespace TdP2019TPFinalRichieri.DAL.EntityFramework
{
    using System.Data.Entity;
    using Entities;

    public class CategoryRepository : Repository<Category, DbContext>, ICategoryRepository
    {
        public CategoryRepository(DbContext pDbContext) : base(pDbContext)
        {
        }
    }
}
