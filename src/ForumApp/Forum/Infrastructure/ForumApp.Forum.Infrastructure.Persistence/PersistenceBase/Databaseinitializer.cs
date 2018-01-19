using System.Data.Entity;

namespace ForumApp.Forum.Infrastructure.Persistence.PersistenceBase
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<ForumContext>
    {
    }
}
