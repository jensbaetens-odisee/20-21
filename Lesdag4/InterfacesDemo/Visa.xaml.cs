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
    /// Interaction logic for Visa.xaml
    /// </summary>
    public partial class Visa : Window
    {
        private bool _visaPaymentSucceeded = false;
        public Visa()
        {
            InitializeComponent();
        }

        public void OpenVisaScreen()
        {
            ShowDialog();
        }

        public bool VisaPaymentSucceeded { get => _visaPaymentSucceeded; }

        private void payButton_Click(object sender, RoutedEventArgs e)
        {
            _visaPaymentSucceeded = true;
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
