using System.Data.Entity;

namespace ForumApp.Identity.Infrastructure.Persistence.PersistenceBase
{
    public class IdentityDatabaseInitializer : IDatabaseInitializer<IdentityAndAccessContext>
    {
        /// <summary>
        /// Initialize the database with the provided data
        /// </summary>
        /// <param name="context"></param>
        public void InitializeDatabase(IdentityAndAccessContext context)
        {
            context.Database.CreateIfNotExists();
        }
    }
}
