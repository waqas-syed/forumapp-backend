using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ForumApp.Identity.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Account repository for all Identity and access related operations
    /// </summary>
    public class AccountRepository : IAccountRepository
    {
        private UserManager<IdentityUser> _userManager;

        public AccountRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            /*var provider = new DpapiDataProtectionProvider("ForumApp");

            userManager.UserTokenProvider = new DataProtectorTokenProvider<IdentityUser>(
                provider.Create("EmailConfirmation"));*/
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IdentityResult RegisterUser(string email, string password)
        {
            // Assign email to the uername property, as we will use email only for authentication as it is a more 
            // clean procedure
            IdentityUser user = new IdentityUser()
            {
                UserName = email,
                Email = email
            };
            IdentityResult result;
            result = _userManager.Create(user, password);

            return result;
        }

        /// <summary>
        /// Get a user by their email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public IdentityUser GetUserByEmail(string email)
        {
            return _userManager.FindByEmail(email);
        }

        /// <summary>
        /// Get a user by their email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public IdentityUser GetUserByPassword(string email, string password)
        {
            return _userManager.Find(email, password);
        }
    }
}
