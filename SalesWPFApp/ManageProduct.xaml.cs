using BusinessObject.DataAccess;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for ManageProduct.xaml
    /// </summary>
    public partial class ManageProduct : Window
    {
        private readonly IGenericRepository<Product> genericRepository = new GenericRepository<Product>();
        private readonly IProductRepository productRepository = new ProductRepository();
        private int CategoryId { get; set; }
        public ManageProduct()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvFlowerBouquets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product product = (Product)lvFlowerBouquets.SelectedItem;
            if (product != null)
            {                
                CategoryId = product.CategoryId;
            }
        }
    }
}
