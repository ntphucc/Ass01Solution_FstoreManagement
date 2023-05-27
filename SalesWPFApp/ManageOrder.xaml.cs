using BusinessObject.DataAccess;
using DataAccess.Repositories;
using SalesWPFApp.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for ManageOrder.xaml
    /// </summary>
    public partial class ManageOrder : Window
    {
        private readonly IGenericRepository<Order> genericRepository = new GenericRepository<Order>();
        private readonly IOrderRepository _orderRepository = new OrderRepository();
        private int? MemberId { get; set; }
        public ManageOrder()
        {
            InitializeComponent();
        }

        private void LoadOrders()
        {
            lvOrders.ItemsSource = genericRepository.GetAll();
            txtName.Text = string.Empty;
            txtSearch.Text = string.Empty;
            message.Text = string.Empty;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadOrders();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadOrders();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text.Length > 0)
            {
                try
                {
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure to delete this order?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        genericRepository.Delete(Int32.Parse(txtId.Text));
                        message.Text = "Delete successfully!";
                        LoadOrders();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete Order");
                }
            }
            else
            {
                message.Text = "Can not find the id!";
            }
        }
        private OrderViewModel GetOrderDetail()
        {
            OrderViewModel order = null;
            try
            {
                order = new OrderViewModel
                {
                    OrderId = Int32.Parse(txtId.Text),
                    MemberId = MemberId,
                    OrderDate = DateTime.ParseExact(txtOrderDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    ShippedDate = DateTime.ParseExact(txtShippedDate.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Freight = decimal.Parse(txTotal.Text),
                };
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Get Order Detail");
            }
            return order;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            OrderDetails orderDetails = new OrderDetails(0, false, null, "Insert an order");
            orderDetails.Show();
            LoadOrders();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text.Length > 0)
            {
                OrderDetails orderDetails = new OrderDetails(Int32.Parse(txtId.Text), true, GetOrderDetail(), "Update an order");
                orderDetails.Show();
                LoadOrders();
            }
            else
            {
                message.Text = "Please choose an order to update!";
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Order order = lvOrders.SelectedItem as Order;
            if (order != null)
            {
                IGenericRepository<Member> memberRepository = new GenericRepository<Member>();
                MemberId = order.MemberId;
                var customer = memberRepository.GetById(MemberId);
                txtName.Text = customer.CompanyName;
            }
        }
    }
}
