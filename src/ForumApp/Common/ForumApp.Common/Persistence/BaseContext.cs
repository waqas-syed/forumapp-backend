using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace ForumApp.Common.Persistence
{
    public class BaseContext : DbContext
    {
        public BaseContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        protected string MODEL_NAMESPACE;

        public void AddObject<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
        }
        
        public void DeleteObject<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
        }
        
        public IQueryable<T> GetQueryableByTableName<T>(string tblName) where T : class
        {
            Type type = GetTypeObject(tblName);
            return GetQueryableByTableName<T>(type);
        }

        public IQueryable<T> GetQueryableByTableName<T>(Type type) where T : class
        {
            return Set(type) as IQueryable<T>;
        }

        public DbSet GetQueryableByTableName(string tblName)
        {
            Type type = GetTypeObject(tblName);
            return GetQueryableByTableName(type);
        }
        public DbSet GetQueryableByTableName(Type type)
        {
            return Set(type);
        }

        public Assembly Assembly()
        {
            var type = this.GetType();
            return System.Reflection.Assembly.GetAssembly(type);
        }
        public T CreateObject<T>(string tblName, string thisNamespace) where T : class
        {
            Assembly asm = Assembly();
            T ret = asm.CreateInstance(thisNamespace + tblName, true) as T;
            return ret;
        }
        public T CreateObject<T>(string tblName) where T : class
        {
            return CreateObject<T>(tblName, MODEL_NAMESPACE);
        }

        public Type GetTypeObject(string tblName, string thisNamespace)
        {
            Assembly asm = Assembly();
            Type type = asm.GetType(thisNamespace + tblName, true, true);
            return type;
        }
        public Type GetTypeObject(string tblName)
        {
            return GetTypeObject(tblName, MODEL_NAMESPACE);
        }
    }
}
