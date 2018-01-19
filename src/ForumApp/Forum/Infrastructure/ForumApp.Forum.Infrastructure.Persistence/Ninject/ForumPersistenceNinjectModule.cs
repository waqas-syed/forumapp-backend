using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApp.Forum.Infrastructure.Persistence.PersistenceBase;
using ForumApp.Forum.Infrastructure.Persistence.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;

namespace ForumApp.Forum.Infrastructure.Persistence.Ninject
{
    public class ForumPersistenceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ForumContext>().ToSelf().InRequestScope();
            Bind<IPostRepository>().To<PostRepository>().InRequestScope();
        }
    }
}
