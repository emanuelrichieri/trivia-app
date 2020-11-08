

namespace TdP2019TPFinalRichieri.DAL.EntityFramework
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {

        public IUnitOfWork GetUnitOfWork()
        {
            return new UnitOfWork(new TriviaDbContext());
        }
    }
}
