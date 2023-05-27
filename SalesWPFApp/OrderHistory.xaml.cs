using DataAccess.Repositories;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for OrderHistory.xaml
    /// </summary>
    public partial class OrderHistory : Window
    {
        private readonly IOrderRepository _orderRepository = new OrderRepository();
        private int memberId;
        public OrderHistory(int memberId)
        {
            InitializeComponent();
            this.memberId = memberId;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lvOrders.ItemsSource = _orderRepository.SearchByMemberID(memberId);
        }
    }
}
