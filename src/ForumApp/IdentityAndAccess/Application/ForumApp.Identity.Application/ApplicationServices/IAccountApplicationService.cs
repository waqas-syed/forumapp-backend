using ForumApp.Identity.Application.ApplicationServices.Commands;
using ForumApp.Identity.Application.ApplicationServices.Representations;

namespace ForumApp.Identity.Application.ApplicationServices
{
    /// <summary>
    /// Application service for Identity's bounded context
    /// </summary>
    public interface IAccountApplicationService
    {
        string Register(CreateUserCommand createUserCommand);

        /// <summary>
        /// Get the user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        UserRepresentation GetUserByEmail(string email);
    }
}
