using BusinessObject.DataAccess;
using DataAccess.Repositories;
using SalesWPFApp.ViewModel;
using System;
using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for MemberDetails.xaml
    /// </summary>
    public partial class MemberDetails : Window
    {
        private IGenericRepository<Member> _memberRepository;
        private bool InsertOrUpdate;
        private MemberViewModel Member;
        public MemberDetails(IGenericRepository<Member> memberRepository, bool insertOrUpdate, MemberViewModel member, string title) 
        {
            InitializeComponent();
            _memberRepository = memberRepository;
            InsertOrUpdate = insertOrUpdate;
            Member = member;
            Title = title;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtId.IsReadOnly = InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtId.Text = Member.MemberId.ToString();
                txtEmail.Text = Member.Email.ToString();
                txtName.Text = Member.CompanyName.ToString();
                txtCity.Text = Member.City.ToString();
                txtCountry.Text = Member.Country.ToString();
                txtPassword.Text = Member.Password.ToString();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var customer = new Member
                {
                    MemberId = int.Parse(txtId.Text),
                    Email = txtEmail.Text,
                    CompanyName = txtName.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text,
                };
                if (InsertOrUpdate == false)
                {
                    _memberRepository.Insert(customer);
                }
                else
                {
                    _memberRepository.Update(customer);
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a customer" : "Update a customer");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
