using BusinessObject.DataAccess;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> SearchByMemberID(int id);
        IEnumerable<Order> ReportOrders(DateTime startDate, DateTime endDate);
    }
}
