using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApp.Forum.Application.ApplicationServices.Commands;
using ForumApp.Forum.Application.ApplicationServices.Representations;
using ForumApp.Forum.Infrastructure.Persistence.PersistenceBase;

namespace ForumApp.Forum.Application.ApplicationServices
{
    /// <summary>
    /// Category Application Service
    /// </summary>
    public class CategoryApplicationService : ICategoryApplicationService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryApplicationService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        
        public IList<CategoryRepresentation> GetAllCategories()
        {
            throw new NotImplementedException();
        }
    }
}
