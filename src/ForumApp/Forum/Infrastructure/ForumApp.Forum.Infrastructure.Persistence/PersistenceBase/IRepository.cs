using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Forum.Infrastructure.Persistence.PersistenceBase
{
    /// <summary>
    /// The base interface for all the repositories that will be introduced into our system
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Add a new entiy to the database
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);

        /// <summary>
        /// Update a stored entity in the database
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Delete the given entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Get all the entities of this type
        /// </summary>
        /// <returns></returns>
        IList<T> GetAll();

        /// <summary>
        /// Get the entity by the given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(string id);
    }
}
