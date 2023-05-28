using BusinessObject.DataAccess;
using DataAccess.Repositories;
using System;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for OrderReport.xaml
    /// </summary>
    public partial class OrderReport : Window
    {
        private readonly IOrderRepository _orderRepository = new OrderRepository();
        private readonly IGenericRepository<Order> _genericRepository = new GenericRepository<Order>();
        public OrderReport()
        {
            InitializeComponent();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lvOrders.ItemsSource = _orderRepository.ReportOrders(DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Order Report");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lvOrders.ItemsSource = _genericRepository.GetAll();
        }
    }
}
