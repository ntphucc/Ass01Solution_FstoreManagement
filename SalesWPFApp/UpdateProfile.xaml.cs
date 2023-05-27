using BusinessObject.DataAccess;
using DataAccess.Repositories;
using SalesWPFApp.ViewModel;
using System;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for UpdateProfile.xaml
    /// </summary>
    public partial class UpdateProfile : Window
    {
        private readonly IGenericRepository<Member> _memberRepository = new GenericRepository<Member>();
        private MemberViewModel Member;
        public UpdateProfile(MemberViewModel member)
        {
            InitializeComponent();
            Member = member;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtId.Text = Member.MemberId.ToString();
            txtEmail.Text = Member.Email.ToString();
            txtName.Text = Member.CompanyName.ToString();
            txtCity.Text = Member.City.ToString();
            txtCountry.Text = Member.Country.ToString();
            txtPassword.Text = Member.Password.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newProfile = new Member
                {
                    MemberId = int.Parse(txtId.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text,
                };
                _memberRepository.Update(newProfile);
                this.Close();
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
