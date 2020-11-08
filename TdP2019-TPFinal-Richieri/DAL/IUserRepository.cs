using System;
namespace TdP2019TPFinalRichieri.DAL
{
    using Entities;
    public interface IUserRepository : IRepository<User>
    {
        User Get(string pUsername);
    }
}
