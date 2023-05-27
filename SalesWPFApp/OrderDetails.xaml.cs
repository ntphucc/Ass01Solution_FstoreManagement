using BusinessObject.DataAccess;
using DataAccess.Repositories;
using SalesWPFApp.ViewModel;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for OrderDetails.xaml
    /// </summary>
    public partial class OrderDetails : Window
    {
        private IGenericRepository<Order> genericRepository = new GenericRepository<Order>();
        private IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
        private int OrderId;
        private bool InsertOrUpdate;
        private OrderViewModel OrderDetail;

        public OrderDetails(int orderId, bool insertOrUpdate, OrderViewModel orderDetail, string title)
        {
            InitializeComponent();
            OrderId = orderId;
            InsertOrUpdate = insertOrUpdate;
            OrderDetail = orderDetail;
            Title = title;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
