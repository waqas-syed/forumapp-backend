using System.Data.Entity;
using ForumApp.Forum.Domain.Model.CategoryAggregate;
using ForumApp.Forum.Domain.Model.PostAggregate;

namespace ForumApp.Forum.Infrastructure.Persistence.PersistenceBase
{
    /// <summary>
    /// The DbContext for the bounded context Forum
    /// </summary>
    public class ForumContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
