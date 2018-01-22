using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;
using System.Web.Http;
using ForumApp.Common.WebHost.Providers;
using ForumApp.Forum.Application.Ninject;
using ForumApp.Forum.Infrastructure.Persistence.Ninject;
using ForumApp.Forum.Ports.Rest.Ninject;
using ForumApp.Identity.Application.Ninject;
using ForumApp.Identity.Infrastructure.Persistence;
using ForumApp.Identity.Ports.Rest.Ninject;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;

[assembly: OwinStartup(typeof(ForumApp.Common.WebHost.Startup))]
namespace ForumApp.Common.WebHost
{
    public class AppBuilderProvider : IDisposable
    {
        private IAppBuilder _app;
        public AppBuilderProvider(IAppBuilder app)
        {
            _app = app;
        }
        public IAppBuilder Get() { return _app; }
        public void Dispose() { }
    }

    public class Startup
    {
        /// <summary>
        /// Configures Identity, OAuth, Cors, Web Api and dependency resolution
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new AppBuilderProvider(app));

            HttpConfiguration configuration = new HttpConfiguration();

            var corsPolicy = new CorsPolicy()
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true,
                SupportsCredentials = true,
                AllowAnyOrigin = true
            };
            
            app.UseCors(new CorsOptions()
            {
                PolicyProvider = new CorsPolicyProvider()
                {
                    PolicyResolver = context => Task.FromResult(corsPolicy)
                }
            });

            ConfigureOAuth(app);
            WebApiConfig.Register(configuration);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(configuration);
        }

        public static IKernel Kernel { get; private set; }

        private StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Load<IdentityPersistenceNinjectModule>();
            kernel.Load<IdentityApplicationNinjectModule>();
            kernel.Load<IdentityPortsNinjectModule>();

            kernel.Load<ForumPersistenceNinjectModule>();
            kernel.Load<ForumApplicationNinjectModule>();
            kernel.Load<ForumPortsNinjectModule>();

            Kernel = kernel;

            return kernel;
        }

        /// <summary>
        /// Configure OAuth
        /// </summary>
        /// <param name="app"></param>
        private void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions oauthOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/v1/account/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(30),
                Provider = new SimpleAuthorizationProvider()
            };

            app.UseOAuthAuthorizationServer(oauthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}