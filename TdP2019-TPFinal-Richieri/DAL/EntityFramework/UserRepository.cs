using System;
namespace TdP2019TPFinalRichieri.DAL.EntityFramework
{
    using System.Data.Entity;
    using Entities;

    public class UserRepository : Repository<User, DbContext>, IUserRepository
    {
        public UserRepository(DbContext pDbContext) : base(pDbContext)
        {
        }

        /// <summary>
        /// Get User with username equals to <paramref name="pUsername"/> 
        /// </summary>
        /// <param name="pUsername">Username.</param>
        public User Get(string pUsername)
        {
            return this.Get(bUser => string.Equals(bUser.Username, pUsername, StringComparison.OrdinalIgnoreCase));
        }

    }
}
