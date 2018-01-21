using System;

namespace ForumApp.Identity.Application.ApplicationServices.Representations
{
    [Serializable]
    public class UserRepresentation
    {
        public UserRepresentation(string email)
        {
            Email = email;
        }
        
        /// <summary>
        /// Email of the user
        /// </summary>
        public string Email { get; set; }
    }
}
