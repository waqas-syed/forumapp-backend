using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Forum.Infrastructure.Persistence.PersistenceBase
{
    /// <summary>
    /// A base implementation of the Irepository that can be used by all of the repositories that inherit the 
    /// IRepository
    /// </summary>
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private ForumContext _forumContext;

        public RepositoryBase(ForumContext forumContext)
        {
            _forumContext = forumContext;
        }

        public void Add(T entity)
        {
            _forumContext.Set<T>().Add(entity);
            _forumContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _forumContext.Set<T>().Attach(entity);
            _forumContext.Entry(entity).State = EntityState.Modified;
            _forumContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _forumContext.Set<T>().Remove(entity);
        }

        public IList<T> GetAll()
        {
            return _forumContext.Set<T>().ToList();
        }

        public T GetById(string id)
        {
            return _forumContext.Set<T>().Find(id);
        }
    }
}
