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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Bancontact.xaml
    /// </summary>
    public partial class Bancontact : Window, IPayable
    {
        private bool _bancontactPaymentSucceeded = false;
        public Bancontact()
        {
            InitializeComponent();
        }

        //interface IPayable
        public void OpenPaymentScreen()
        {
            ShowDialog();
        }

        public bool PaymentSucceeded => _bancontactPaymentSucceeded;

        public string PaymentSucceededMessage
        {
            get => "Payment with banccontact succeeded";
        }

        public string PaymentFailedMessage
        {
            get => "Payment with banccontact failed";
        }
        // end interface IPayable

        private void payButton_Click(object sender, RoutedEventArgs e)
        {
            _bancontactPaymentSucceeded = true;
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
