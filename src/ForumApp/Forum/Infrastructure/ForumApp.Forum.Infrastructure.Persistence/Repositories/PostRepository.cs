using ForumApp.Forum.Domain.Model.PostAggregate;
using ForumApp.Forum.Infrastructure.Persistence.PersistenceBase;
using System.Data.Entity;
using System.Linq;

namespace ForumApp.Forum.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Repository for Posts
    /// </summary>
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        private ForumContext _forumContext;
        public PostRepository(ForumContext forumContext) : base(forumContext)
        {
            _forumContext = forumContext;
        }

        public Post GetPostById(string postId)
        {
            return _forumContext.Set<Post>().Include(u => u.Comments).First(x => x.Id == postId);
        }
    }
}
