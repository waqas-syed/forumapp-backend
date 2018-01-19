using System.Data.Entity;
using ForumApp.Forum.Domain.Model.CategoryAggregate;
using ForumApp.Forum.Domain.Model.PostAggregate;
using ForumApp.Forum.Infrastructure.Persistence.Configurations;

namespace ForumApp.Forum.Infrastructure.Persistence.PersistenceBase
{
    /// <summary>
    /// The DbContext for the bounded context Forum
    /// </summary>
    public class ForumContext : DbContext
    {
        public ForumContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
        }
    }
}
