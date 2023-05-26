using BusinessObject.DataAccess;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<Product> SearchByName(string name) => ProductDAO.Instance.SearchByName(name);
    }
}
