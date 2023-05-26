using BusinessObject.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new object();

        private OrderDetailDAO()
        {
        }

        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null) instance = new OrderDetailDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<OrderDetail> GetOrderDetails(int id)
        {
            using (var context = new FstoreContext())
            {
                return context.OrderDetails.Where(c => c.OrderId == id).ToList();
            }
        }

        public void AddOrderDetail(OrderDetail orderDetail, Order newOrder)
        {
            using (var context = new FstoreContext())
            {
                var order = context.Orders.SingleOrDefault(o => o.OrderId == orderDetail.OrderId);
                if (order == null)
                {
                    order = new Order
                    {
                        OrderId = newOrder.OrderId,
                        MemberId = newOrder.MemberId,
                        OrderDate = newOrder.OrderDate,
                        ShippedDate = newOrder.ShippedDate,
                        RequiredDate = newOrder.RequiredDate,
                        Freight = newOrder.Freight
                    };
                    context.Orders.Add(order);
                }
                order.OrderDetails.Add(new OrderDetail
                {
                    OrderId = orderDetail.OrderId,
                    ProductId = orderDetail.ProductId,
                    UnitPrice = orderDetail.UnitPrice,
                    Quantity = orderDetail.Quantity,
                    Discount = orderDetail.Discount
                });
                context.SaveChanges();
            }
        }

        public OrderDetail CheckProduct(int flowerBouquetiId, int orderId)
        {
            using (var context = new FstoreContext())
            {
                return context.OrderDetails.Where(c => c.ProductId == flowerBouquetiId && c.OrderId == orderId).FirstOrDefault();
            }
        }

        public void DeleteOrderDetails(int orderId, int flowerBouquetId)
        {
            using (var context = new FstoreContext())
            {
                var order = context.Orders.Include(o => o.OrderDetails).SingleOrDefault(o => o.OrderId == orderId);
                if (order != null)
                {
                    foreach (var orderDetail in order.OrderDetails.Where(f => f.ProductId == flowerBouquetId))
                    {
                        order.OrderDetails.Remove(orderDetail);
                    }
                    context.SaveChanges();
                }
            }
        }

        public void UpdateOrderDetails(OrderDetail orderDetail)
        {
            using (var context = new FstoreContext())
            {
                var order = context.Orders.Include(o => o.OrderDetails).SingleOrDefault(o => o.OrderId == orderDetail.OrderId);
                if (order != null)
                {
                    order.OrderDetails.Add(orderDetail);
                    context.SaveChanges();
                }
            }
        }

        public OrderDetail CheckForUpdate(int flowerBouquetiId, int orderId, int newFlowerBouquetId)
        {
            using (var context = new FstoreContext())
            {
                var order = context.Orders.Include(o => o.OrderDetails).SingleOrDefault(o => o.OrderId == orderId);
                return order.OrderDetails.Where(c => c.ProductId != flowerBouquetiId && c.ProductId == newFlowerBouquetId).FirstOrDefault();
            }
        }
    }
}
