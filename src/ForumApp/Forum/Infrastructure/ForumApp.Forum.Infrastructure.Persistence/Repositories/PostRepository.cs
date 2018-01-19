using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApp.Forum.Domain.Model.PostAggregate;
using ForumApp.Forum.Infrastructure.Persistence.PersistenceBase;

namespace ForumApp.Forum.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Repository for Posts
    /// </summary>
    public class PostRepository : RepositoryBase<Post>
    {
        public PostRepository(ForumContext forumContext) : base(forumContext)
        {
            
        }
    }
}
