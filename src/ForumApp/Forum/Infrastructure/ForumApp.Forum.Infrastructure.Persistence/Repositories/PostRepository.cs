using ForumApp.Forum.Domain.Model.PostAggregate;
using ForumApp.Forum.Infrastructure.Persistence.PersistenceBase;

namespace ForumApp.Forum.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Repository for Posts
    /// </summary>
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(ForumContext forumContext) : base(forumContext)
        {
            
        }
    }
}
