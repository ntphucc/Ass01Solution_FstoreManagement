using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        void Insert(T obj);
        void Update(T obj);
        IEnumerable<T> GetAll();
        void Delete(object id);
        T GetById(object id);
    }
}
