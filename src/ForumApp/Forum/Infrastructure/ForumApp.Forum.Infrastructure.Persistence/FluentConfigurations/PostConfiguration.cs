using System.Data.Entity.ModelConfiguration;
using ForumApp.Forum.Domain.Model.PostAggregate;

namespace ForumApp.Forum.Infrastructure.Persistence.FluentConfigurations
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            ToTable("post");
            HasKey(x => x.Id);
            Property(x => x.Title).IsRequired().HasMaxLength(100);
            Property(x => x.Description).IsRequired().HasMaxLength(4000);
        }
    }
}
