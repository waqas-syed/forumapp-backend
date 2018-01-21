using ForumApp.Identity.Application.ApplicationServices;
using Ninject.Modules;
using Ninject.Web.Common;

namespace ForumApp.Identity.Application.Ninject
{
    /// <summary>
    /// Ninject Module
    /// </summary>
    public class IdentityApplicationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAccountApplicationService>().To<AccountApplicationService>().InRequestScope();
        }
    }
}
