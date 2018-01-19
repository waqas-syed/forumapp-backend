using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApp.Forum.Domain.Model.CategoryAggregate;
using ForumApp.Forum.Domain.Model.PostAggregate;

namespace ForumApp.Forum.Infrastructure.Persistence.Configurations
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
