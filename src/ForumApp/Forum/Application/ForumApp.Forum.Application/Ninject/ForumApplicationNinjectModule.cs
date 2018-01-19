using ForumApp.Forum.Application.ApplicationServices;
using Ninject.Modules;
using Ninject.Web.Common;

namespace ForumApp.Forum.Application.Ninject
{
    public class ForumApplicationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPostApplicationService>().To<PostApplicationService>().InRequestScope();
        }
    }
}
