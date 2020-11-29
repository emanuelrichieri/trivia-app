using System.Data.Entity;

namespace TdP2019TPFinalRichieri.DAL.EntityFramework
{
    using Entities;
    using Migrations;

    public class TriviaDbContext : DbContext
    {
        public TriviaDbContext() : base("TriviaDb")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TriviaDbContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder pModelBuilder)
        {
            pModelBuilder.Configurations.AddFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());

            pModelBuilder.Entity<Session>()
                        .HasMany(session => session.Questions)
                        .WithMany();

            pModelBuilder.Entity<SessionAnswer>()
                        .HasMany(sessionAnswer => sessionAnswer.Answers)
                        .WithMany();

            base.OnModelCreating(pModelBuilder);
        }

        public IDbSet<QuestionsSet> QuestionsSets { get; set; }

        public IDbSet<Question> Questions { get; set; }

        public IDbSet<Session> Sessions { get; set; }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Level> Levels { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<SessionAnswer> SessionAnswers { get; set; }

        public IDbSet<Answer> Answers { get; set; }
    }
}
