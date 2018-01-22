using ForumApp.Identity.Infrastructure.Persistence.PersistenceBase;
using ForumApp.Identity.Infrastructure.Persistence.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject.Modules;
using Ninject.Web.Common;

namespace ForumApp.Identity.Infrastructure.Persistence
{
    /// <summary>
    /// Ninject module for Identity's Persistence layer
    /// </summary>
    public class IdentityPersistenceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IdentityAndAccessContext>().ToSelf().InRequestScope();
            Bind(typeof(IUserStore<IdentityUser>)).To<UserStore<IdentityUser>>().InRequestScope();
            Bind(typeof(UserManager<IdentityUser>)).ToSelf().InRequestScope();
            Bind<IAccountRepository>().To<AccountRepository>().InRequestScope();
        }
    }
}
