using ForumApp.Forum.Domain.Model.CategoryAggregate;
using ForumApp.Forum.Infrastructure.Persistence.PersistenceBase;

namespace ForumApp.Forum.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Category Repository
    /// </summary>
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(ForumContext forumContext) : base(forumContext)
        {
        }
    }
}
