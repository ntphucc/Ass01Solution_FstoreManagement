using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<Order> ReportOrders(DateTime startDate, DateTime endDate) => OrderDAO.Instance.ReportOrders(startDate, endDate);

        public IEnumerable<Order> SearchByMemberID(int id) => OrderDAO.Instance.SearchByMemberID(id);
    }
}
