using BusinessObject.DataAccess;
using DataAccess.Repositories;
using SalesWPFApp.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

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

        private void LoadProducts()
        {
            lvFlowerBouquets.ItemsSource = genericRepository.GetAll();
            message.Text = "";
            txtSearch.Text = "";
        }

        private ProductViewModel GetProductDetail()
        {
            ProductViewModel product = null;
            try
            {
                product = new ProductViewModel
                {
                    ProductId = Int32.Parse(txtId.Text),
                    ProductName = txtName.Text,
                    Weight = txtDescription.Text,
                    UnitPrice = decimal.Parse(txtPrice.Text),
                    UnitsInStock = Int32.Parse(txtUis.Text),
                    CategoryId = CategoryId,
                };
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Get Flower Bouquet Detail");
            }
            return product;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadProducts();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text.Length > 0)
            {
                ProductDetails productDetails = new ProductDetails(genericRepository, true, GetProductDetail(), "Update a product");
                productDetails.Show();
                LoadProducts();
            }
            else
            {
                message.Text = "Please choose a flower bouquet to update!";
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                lvFlowerBouquets.ItemsSource = productRepository.SearchByName(txtSearch.Text);
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadProducts();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            ProductDetails productDetails = new ProductDetails(genericRepository, true, GetProductDetail(), "Insert a product");
            productDetails.Show();
            LoadProducts();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text.Length > 0)
            {
                try
                {
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure to delete this product?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        IGenericRepository<OrderDetail> orderDetailRepository = new GenericRepository<OrderDetail>();
                        var orderDetails = orderDetailRepository.GetAll();
                        var check = false;
                        foreach (var orderDetail in orderDetails)
                        {
                            if (orderDetail.ProductId == Int32.Parse(txtId.Text))
                            {
                                check = true;
                                break;
                            }
                        }
                        if (check == false)
                        {
                            genericRepository.Delete(Int32.Parse(txtId.Text));
                            message.Text = "Delete successfully!";
                        }
                        else
                        {
                            var product = new Product
                            {
                                ProductId = Int32.Parse(txtId.Text),
                                ProductName = txtName.Text,
                                Weight = txtDescription.Text,
                                UnitPrice = decimal.Parse(txtPrice.Text),
                                UnitslnStock = Int32.Parse(txtUis.Text),
                                CategoryId = CategoryId,
                            };
                            genericRepository.Update(product);
                            message.Text = "This product is stored in an order!";
                        }
                        LoadProducts();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete Product");
                }
            }
            else
            {
                message.Text = "Can not find the id!";
            }
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
