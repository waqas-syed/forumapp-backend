using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApp.Identity.Application.ApplicationServices;
using ForumApp.Identity.Infrastructure.Persistence.Repositories;
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
