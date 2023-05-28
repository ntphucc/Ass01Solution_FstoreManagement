using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, RoutedEventArgs e)
        {
            ManageCustomers manageCustomers = new ManageCustomers();
            manageCustomers.Show();
        }

        private void btnFlower_Click(object sender, RoutedEventArgs e)
        {
            ManageProduct manageProduct = new ManageProduct();
            manageProduct.Show();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            ManageOrder manageOrder = new ManageOrder();
            manageOrder.Show();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            OrderReport orderReport = new OrderReport();
            orderReport.Show();
        }
    }
}
