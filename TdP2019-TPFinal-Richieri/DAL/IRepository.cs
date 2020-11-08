using System;
using System.Collections.Generic;

namespace TdP2019TPFinalRichieri.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {

        /// <summary>
        /// Persist the given entity to the DB.
        /// </summary>
        /// <param name="pEntity">Entity to add.</param>
        void Add(TEntity pEntity);

        /// <summary>
        /// Delete the given entity from the DB.
        /// </summary>
        /// <param name="pEntity">Entity to remove.</param>
        void Remove(TEntity pEntity);

        /// <summary>
        /// Get entity by identifier (primary key).
        /// </summary>
        /// <returns>The entity, if exists. null otherwise</returns>
        /// <param name="pId">Entity identifier.</param>
        TEntity Get(int pId);

        /// <summary>
        /// Get all entities stored in the DB.
        /// </summary>
        /// <returns>Entity List.</returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Get all entities that match to the given predicate.
        /// </summary>
        /// <returns>Entity list.</returns>
        /// <param name="pPredicate">Predicate.</param>
        IEnumerable<TEntity> GetWhere(Func<TEntity, bool> pPredicate);

        /// <summary>
        /// Get first entity that matches to the given predicate.
        /// </summary>
        /// <returns>
        ///         The entity, if at least one was found. 
        ///         Null otherwise
        /// </returns>
        /// <param name="pPredicate">Predicate.</param>
        TEntity Get(Func<TEntity, bool> pPredicate);
    }
}
