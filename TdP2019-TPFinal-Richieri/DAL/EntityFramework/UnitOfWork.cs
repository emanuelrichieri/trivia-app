using System;
using System.Data.Entity;

namespace TdP2019TPFinalRichieri.DAL.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _dbContext;
        private bool _disposedValue = false;
        
        public UnitOfWork(DbContext pDbContext) :
            this(pDbContext,
                new QuestionRepository(pDbContext),
                new QuestionsSetRepository(pDbContext),
                new SessionRepository(pDbContext),
                new UserRepository(pDbContext),
                new LevelRepository(pDbContext),
                new CategoryRepository(pDbContext),
                new SessionAnswerRepository(pDbContext)
                ) { }

        public UnitOfWork(DbContext pDbContext,
                IQuestionRepository pQuestionRepository,
                IQuestionsSetRepository pQuestionsSetRepository,
                ISessionRepository pSessionRepository,
                IUserRepository pUserRepository,
                ILevelRepository pLevelRepository,
                ICategoryRepository pCategoryRepository,
                ISessionAnswerRepository pSessionAnswerRepository
            )
        {
            this._dbContext = pDbContext ?? throw new NotImplementedException();
            this.QuestionRepository = pQuestionRepository;
            this.QuestionsSetRepository = pQuestionsSetRepository;
            this.SessionRepository = pSessionRepository;
            this.UserRepository = pUserRepository;
            this.LevelRepository = pLevelRepository;
            this.CategoryRepository = pCategoryRepository;
            this.SessionAnswerRepository = pSessionAnswerRepository;
        }

        public IQuestionRepository QuestionRepository { get; private set; }

        public IQuestionsSetRepository QuestionsSetRepository { get; private set; }

        public ISessionRepository SessionRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public ILevelRepository LevelRepository { get; private set; }

        public ICategoryRepository CategoryRepository { get; private set; }

        public ISessionAnswerRepository SessionAnswerRepository { get; private set; }


        public void Complete()
        {
            this._dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool pDisposing)
        {
            if (!this._disposedValue)
            {
                if (pDisposing)
                {
                    this._dbContext.Dispose();
                }

                this._disposedValue = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
        }
    }
}
