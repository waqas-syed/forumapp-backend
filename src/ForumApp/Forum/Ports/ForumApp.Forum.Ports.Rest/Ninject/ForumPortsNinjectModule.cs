using ForumApp.Forum.Ports.Rest.Controllers;
using Ninject.Modules;

namespace ForumApp.Forum.Ports.Rest.Ninject
{
    public class ForumPortsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<PostController>().ToSelf().InTransientScope();
        }
    }
}
