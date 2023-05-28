using BusinessObject.DataAccess;
using DataAccess.Repositories;
using SalesWPFApp.ViewModel;
using System;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for ProductDetails.xaml
    /// </summary>
    public partial class ProductDetails : Window
    {
        private IGenericRepository<Product> _productRepository;
        private bool InsertOrUpdate;
        private ProductViewModel productDetail;

        public ProductDetails(IGenericRepository<Product> repository, bool insertOrUpdate, ProductViewModel productDetail, string title)
        {
            InitializeComponent();
            _productRepository = repository;
            InsertOrUpdate = insertOrUpdate;
            this.productDetail = productDetail;
            Title = title;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtId.IsReadOnly = InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtId.Text = productDetail.ProductId.ToString();
                txtName.Text = productDetail.ProductName.ToString();
                txtDescription.Text = productDetail.Weight.ToString();
                txtPrice.Text = productDetail.UnitPrice.ToString();
                txtUis.Text = productDetail.UnitsInStock.ToString();
                txtCategoryId.Text = productDetail.CategoryId.ToString();
            } else
            {
                txtId.Text = string.Empty;
                txtName.Text = string.Empty;
                txtDescription.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtUis.Text = string.Empty;
                txtCategoryId.Text = string.Empty;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = new Product
                {
                    ProductId = Int32.Parse(txtId.Text),
                    ProductName = txtName.Text,
                    Weight = txtDescription.Text,
                    UnitPrice = decimal.Parse(txtPrice.Text),
                    UnitslnStock = Int32.Parse(txtUis.Text),
                    CategoryId = Convert.ToInt32(txtCategoryId.Text),
                };
                if (InsertOrUpdate == false)
                {
                    _productRepository.Insert(product);
                }
                else
                {
                    _productRepository.Update(product);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a ;product" : "Update a product");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
