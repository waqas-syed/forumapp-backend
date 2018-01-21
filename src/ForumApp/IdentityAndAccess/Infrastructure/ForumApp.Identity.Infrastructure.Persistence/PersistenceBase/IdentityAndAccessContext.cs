using Microsoft.AspNet.Identity.EntityFramework;

namespace ForumApp.Identity.Infrastructure.Persistence.PersistenceBase
{
    /// <summary>
    /// Context for the IdentityAndAccess bounded context
    /// </summary>
    public class IdentityAndAccessContext : IdentityDbContext<IdentityUser>
    {
        public IdentityAndAccessContext() : base("DefaultConnection")
        {
        }
    }
}
