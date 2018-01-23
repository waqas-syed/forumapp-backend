using ForumApp.Forum.Domain.Model.CategoryAggregate;

namespace ForumApp.Forum.Infrastructure.Persistence.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ForumApp.Forum.Infrastructure.Persistence.PersistenceBase.ForumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ForumApp.Forum.Infrastructure.Persistence.PersistenceBase.ForumContext context)
        {
            context.Categories.Add(new Category("Sports"));
            context.Categories.Add(new Category("Technology"));
            context.Categories.Add(new Category("Politics"));
            context.Categories.Add(new Category("Travel"));
            context.Categories.Add(new Category("Lifestyle"));
            context.Categories.Add(new Category("Science"));
            context.Categories.Add(new Category("Current Affairs"));
        }
    }
}
