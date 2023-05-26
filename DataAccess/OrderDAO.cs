using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new object();

        private OrderDAO()
        {
        }

        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null) instance = new OrderDAO();
                    return instance;
                }
            }
        }

        public IEnumerable<Order> SearchByMemberID(int id)
        {
            using (var context = new FstoreContext())
            {
                return context.Orders.Where(c => c.MemberId == id).ToList();
            }
        }

        public IEnumerable<Order> ReportOrders(DateTime startDate, DateTime endDate)
        {
            using (var context = new FstoreContext())
            {
                return context.Orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate).OrderByDescending(o => o.OrderDate).ToList();
            }
        }
    }
}
