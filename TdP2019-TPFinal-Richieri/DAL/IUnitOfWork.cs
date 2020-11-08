using System;
namespace TdP2019TPFinalRichieri.DAL
{
    public interface IUnitOfWork : IDisposable
    {

        IQuestionRepository QuestionRepository { get; }

        IQuestionsSetRepository QuestionsSetRepository { get; }

        ISessionRepository SessionRepository { get; }

        IUserRepository UserRepository { get; }

        ILevelRepository LevelRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        ISessionAnswerRepository SessionAnswerRepository { get; }

        void Complete();
    }
}
