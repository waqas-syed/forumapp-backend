using ForumApp.Forum.Domain.Model.PostAggregate;

namespace ForumApp.Forum.Infrastructure.Persistence.PersistenceBase
{
    public interface IPostRepository : IRepository<Post>
    {
        //void AddComment(Comment comment);
    }
}
