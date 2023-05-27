using BusinessObject.DataAccess;
using DataAccess.Repositories;
using SalesWPFApp.ViewModel;
using System;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        private readonly IGenericRepository<Member> _memberRepository = new GenericRepository<Member>();
        private int memberId;
        public Profile(int memberId)
        {
            InitializeComponent();
            this.memberId = memberId;
        }
        
        private void LoadMember()
        {
            var customer = _memberRepository.GetById(memberId);
            txtId.Text = customer.MemberId.ToString();
            txtEmail.Text = customer.Email.ToString();
            txtName.Text = customer.CompanyName.ToString();
            txtCity.Text = customer.City.ToString();
            txtCountry.Text = customer.Country.ToString();
            txtPassword.Text = customer.Password.ToString();
        }

        private void ProfileWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMember();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadMember();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newProfile = new MemberViewModel
                {
                    MemberId = int.Parse(txtId.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text,
                };
                UpdateProfile updateProfile = new UpdateProfile(newProfile);
                updateProfile.Show();
                LoadMember();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Profile");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
