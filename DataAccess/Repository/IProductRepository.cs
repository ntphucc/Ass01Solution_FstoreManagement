using BusinessObject.DataAccess;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> SearchByName(string name);
    }
}
