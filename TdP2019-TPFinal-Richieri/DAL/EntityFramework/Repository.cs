using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
namespace TdP2019TPFinalRichieri.DAL.EntityFramework
{
    public abstract class Repository<TEntity, TDbContext> : IRepository<TEntity> where TEntity : class
                                                                                 where TDbContext : DbContext
    {

        protected readonly TDbContext _dbContext;

        protected Repository(TDbContext pDbContext)
        {
            this._dbContext = pDbContext ?? throw new ArgumentNullException(nameof(pDbContext));
        }

        public void Add(TEntity pEntity)
        {
            if (pEntity == null)
            {
                throw new ArgumentNullException(nameof(pEntity));
            }

            this._dbContext.Set<TEntity>().Add(pEntity);
        }

        public TEntity Get(int pId)
        {
            return this._dbContext.Set<TEntity>().Find(pId);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this._dbContext.Set<TEntity>();
        }

        public void Remove(TEntity pEntity)
        {
            if (pEntity == null)
            {
                throw new ArgumentNullException(nameof(pEntity));
            }

            this._dbContext.Set<TEntity>().Remove(pEntity);
        }


        public IEnumerable<TEntity> GetWhere(Func<TEntity, bool> pPredicate)
        {
            if (pPredicate == null)
            {
                throw new ArgumentNullException(nameof(pPredicate));
            }
            return this.GetAll().Where(pPredicate);
        }

        public TEntity Get(Func<TEntity, bool> pPredicate)
        {
            IEnumerable<TEntity> results = this.GetWhere(pPredicate);
            if (results.Any())
            {
                return results.First();
            }
            return null;
        }
    }
}
