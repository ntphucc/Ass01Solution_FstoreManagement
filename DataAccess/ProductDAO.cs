using BusinessObject.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();

        private ProductDAO()
        {
        }

        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null) instance = new ProductDAO();
                    return instance;
                }
            }
        }
        public IEnumerable<Product> SearchByName(string name)
        {
            using (var context = new FstoreContext())
            {
                return context.Products.Where(c => c.ProductName.Contains(name)).ToList();
            }
        }
    }
}
