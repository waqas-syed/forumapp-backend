using ForumApp.Identity.Ports.Rest.Controllers;
using Ninject.Modules;
using Ninject.Web.Common;

namespace ForumApp.Identity.Ports.Rest.Ninject
{
    /// <summary>
    /// Ninject Module for the Identity Ports layer
    /// </summary>
    public class IdentityPortsNinjectModule : NinjectModule
    {
        /// <summary>
        /// Load the given entities
        /// </summary>
        public override void Load()
        {
            Bind<AccountController>().ToSelf().InRequestScope();
        }
    }
}
