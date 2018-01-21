using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ForumApp.Identity.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Handles all the operations related to the persistence of the Identity and access bounded context
    /// </summary>
    public interface IAccountRepository
    {
        /// <summary>
        /// Register a new user into our system
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        IdentityResult RegisterUser(string email, string password);

        /// <summary>
        /// Get a user by their email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        IdentityUser GetUserByEmail(string email);

        /// <summary>
        /// Get a user by their email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        IdentityUser GetUserByPassword(string email, string password);
    }
}
