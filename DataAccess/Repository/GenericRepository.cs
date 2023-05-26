using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private GenericDAO<T> dao = new GenericDAO<T>();

        public void Delete(object id) => dao.Delete(id);

        public IEnumerable<T> GetAll() => dao.GetAll();

        public T GetById(object id) => dao.GetById(id);

        public void Insert(T obj) => dao.Insert(obj);

        public void Update(T obj) => dao.Update(obj);
        
    }
}
