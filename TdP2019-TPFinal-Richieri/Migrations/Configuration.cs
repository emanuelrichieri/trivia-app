using System.Data.Entity.Migrations;

namespace TdP2019TPFinalRichieri.Migrations
{
    using DAL.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<TriviaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TdP2019TPFinalRichieri.DAL.EntityFramework.TriviaDbContext";
        }

        protected override void Seed(TriviaDbContext pContext)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
