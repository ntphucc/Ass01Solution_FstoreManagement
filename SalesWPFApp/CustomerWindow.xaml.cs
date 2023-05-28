using System.Windows;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private int memberId;
        public CustomerWindow(int memberId)
        {
            InitializeComponent();
            this.memberId = memberId;
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            Profile profile = new Profile(memberId);
            profile.Show();
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            OrderHistory orderHistory = new OrderHistory(memberId);
            orderHistory.Show();
        }
    }
}
