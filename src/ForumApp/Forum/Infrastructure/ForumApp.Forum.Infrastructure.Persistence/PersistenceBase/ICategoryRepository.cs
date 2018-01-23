using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumApp.Forum.Domain.Model.CategoryAggregate;

namespace ForumApp.Forum.Infrastructure.Persistence.PersistenceBase
{
    /// <summary>
    /// Repository for all operations related to Category
    /// </summary>
    public interface ICategoryRepository : IRepository<Category>
    {

    }
}
