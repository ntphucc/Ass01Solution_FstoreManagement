using BusinessObject.DataAccess;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetOrderDetails(int id);
        void AddOrderDetail(OrderDetail orderDetail, Order order);
        OrderDetail CheckProduct(int productId, int orderId);
        void DeleteOrderDetails(int orderId, int productId);
        void UpdateOrderDetails(OrderDetail orderDetail);
        OrderDetail CheckForUpdate(int productId, int orderId, int newProductId);
    }
}
