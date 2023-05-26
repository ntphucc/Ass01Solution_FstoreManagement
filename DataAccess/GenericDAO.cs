using BusinessObject.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class GenericDAO <T> where T : class
    {
        public GenericDAO() { }

        public void Update(T obj)
        {
            using (var context = new FstoreContext())
            {
                context.Set<T>().Attach(obj);
                context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Insert(T obj)
        {
            using (var context = new FstoreContext())
            {
                context.Set<T>().Add(obj);
                context.SaveChanges();
            }
        }

        public void Delete(object id)
        {
            using (var context = new FstoreContext())
            {
                T existing = context.Set<T>().Find(id);
                context.Set<T>().Remove(existing);
                context.SaveChanges();
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var context = new FstoreContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public T GetById(object id)
        {
            using (var context = new FstoreContext())
            {
                return context.Set<T>().Find(id);
            }
        }

    }
}
