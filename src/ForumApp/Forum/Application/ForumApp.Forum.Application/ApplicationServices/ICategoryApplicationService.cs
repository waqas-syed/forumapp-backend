using ForumApp.Forum.Application.ApplicationServices.Commands;
using ForumApp.Forum.Application.ApplicationServices.Representations;
using System.Collections.Generic;

namespace ForumApp.Forum.Application.ApplicationServices
{
    /// <summary>
    /// Handles all operations related to Categories
    /// </summary>
    public interface ICategoryApplicationService
    {
        IList<CategoryRepresentation> GetAllCategories();
    }
}
