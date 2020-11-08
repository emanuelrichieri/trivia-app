using System.Data.Entity;

namespace TdP2019TPFinalRichieri.DAL
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork GetUnitOfWork();
    }
}
