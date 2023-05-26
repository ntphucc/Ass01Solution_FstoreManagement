using BusinessObject.DataAccess;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void AddOrderDetail(OrderDetail orderDetail, Order order) => OrderDetailDAO.Instance.AddOrderDetail(orderDetail, order);

        public OrderDetail CheckProduct(int productId, int orderId) => OrderDetailDAO.Instance.CheckProduct(productId, orderId);

        public OrderDetail CheckForUpdate(int productId, int orderId, int newProductId) => OrderDetailDAO.Instance.CheckForUpdate(productId, orderId, newProductId);

        public void DeleteOrderDetails(int orderId, int productId) => OrderDetailDAO.Instance.DeleteOrderDetails(orderId, productId);

        public IEnumerable<OrderDetail> GetOrderDetails(int id) => OrderDetailDAO.Instance.GetOrderDetails(id);

        public void UpdateOrderDetails(OrderDetail orderDetail) => OrderDetailDAO.Instance.UpdateOrderDetails(orderDetail);
    }
}
