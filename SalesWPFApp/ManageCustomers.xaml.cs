using BusinessObject.DataAccess;
using DataAccess.Repositories;
using SalesWPFApp.ViewModel;
using System;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for ManageCustomers.xaml
    /// </summary>
    public partial class ManageCustomers : Window
    {
        private readonly IMemberRepository _memberRepository = new MemberRepository();
        private readonly IGenericRepository<Member> _genericRepository = new GenericRepository<Member>();
        public ManageCustomers()
        {
            InitializeComponent();
        }
        private void LoadMembers()
        {
            lvCustomers.ItemsSource = _genericRepository.GetAll();
            message.Text = "";
        }

        private MemberViewModel GetCustomerDetail()
        {
            MemberViewModel member = null;
            try
            {
                member = new MemberViewModel
                {
                    MemberId = int.Parse(txtId.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text,
                };
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Get Customer Detail");
            }
            return member;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMembers();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text.Length > 0)
            {
                MemberDetails customerDetails = new MemberDetails(_genericRepository, true, GetCustomerDetail(), "Update a customer");
                customerDetails.Show();
                LoadMembers();
            }
            else
            {
                message.Text = "Please choose a customer to update!";
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadMembers();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            MemberDetails customerDetails = new MemberDetails(_genericRepository, false, null, "Insert a customer");
            customerDetails.Show();
            LoadMembers();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtId.Text.Length > 0)
            {
                try
                {
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure to delete this customer?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        _genericRepository.Delete(Int32.Parse(txtId.Text));
                        message.Text = "Delete successfully!";
                        LoadMembers();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete Customer");
                }
            }
            else
            {
                message.Text = "Can not find the id!";
            }
        }
    }
}
