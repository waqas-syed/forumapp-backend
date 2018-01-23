using ForumApp.Forum.Application.ApplicationServices.Representations;
using ForumApp.Forum.Domain.Model.CategoryAggregate;
using ForumApp.Forum.Infrastructure.Persistence.PersistenceBase;
using System.Collections.Generic;

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
            var categories = _categoryRepository.GetAll();
            return ConvertCategoriesToRepresentations(categories);
        }

        #region Private Helpers

        /// <summary>
        /// Because we are using the CQRS pattern, we will convert the categories to their 
        /// corresponding representations so that we are not exposing our Domain Model 
        /// to the outside world even in the future
        /// </summary>
        /// <returns></returns>
        private IList<CategoryRepresentation> ConvertCategoriesToRepresentations(IList<Category> categories)
        {
            var categoryRepresentations = new List<CategoryRepresentation>();
            foreach (var category in categories)
            {
                categoryRepresentations.Add(new CategoryRepresentation()
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }
            return categoryRepresentations;
        }

        #endregion Private Helpers
    }
}
