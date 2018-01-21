using ForumApp.Identity.Application.ApplicationServices.Commands;
using ForumApp.Identity.Application.ApplicationServices.Representations;
using ForumApp.Identity.Infrastructure.Persistence.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;

namespace ForumApp.Identity.Application.ApplicationServices
{
    /// <summary>
    /// Account Application Service
    /// </summary>
    public class AccountApplicationService : IAccountApplicationService
    {
        private IAccountRepository _accountRepository;

        public AccountApplicationService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="createUserCommand"></param>
        public string Register(CreateUserCommand createUserCommand)
        {
            if (!createUserCommand.Password.Equals(createUserCommand.ConfirmPassword))
            {
                throw new InvalidOperationException("Password and Confirm password are not equal");
            }
            // Register the User
            IdentityResult registrationResult = _accountRepository.RegisterUser(
                createUserCommand.Email,
                createUserCommand.Password);
            if (registrationResult == null)
            {
                throw new NullReferenceException("Unexpected error happened while registering the user");
            }
            if (!registrationResult.Succeeded)
            {
                throw new InvalidOperationException(registrationResult.Errors.First());
            }
            // Get the User instance to have her Id
            var retreivedUser = _accountRepository.GetUserByEmail(createUserCommand.Email);

            return retreivedUser.Id;
        }

        /// <summary>
        /// Get a uer by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public UserRepresentation GetUserByEmail(string email)
        {
            IdentityUser customIdentityUser = _accountRepository.GetUserByEmail(email);
            if (customIdentityUser != null)
            {
                return new UserRepresentation(customIdentityUser.Email);
            }
            throw new NullReferenceException("Could not find the user for the given email");
        }
    }
}
