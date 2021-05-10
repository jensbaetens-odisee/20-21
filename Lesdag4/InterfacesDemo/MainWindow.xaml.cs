using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            List<StockItem> stockItems = new List<StockItem>()
            {
                new StockItem("Brood", 2.5),
                new StockItem("Hesp", 3),
                new StockItem("Kaas", 2.10),
                new StockItem("Wijn", 7.85),
                new StockItem("Melk", 2)
            };

            stockListBox.ItemsSource = stockItems;
        }


        private void stockListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (stockListBox.SelectedItem != null)
            {
                var item = (StockItem)stockListBox.SelectedItem;
                List<StockItem> items = (List<StockItem>)stockListBox.ItemsSource;
                items.Remove(item);
                stockListBox.ItemsSource = null;
                stockListBox.ItemsSource = items;
                orderListBox.Items.Add(item);
                SetTotalAmount();
            }
        }

        private void SetTotalAmount()
        {
            double totalAmount = 0;
            foreach (StockItem item in orderListBox.Items)
            {
                totalAmount += item.Price;
            }

            totalAmountLabel.Content = totalAmount;
        }

        private void payButton_Click(object sender, RoutedEventArgs e)
        {
            // Implementeer deze knop zodanig dat het juiste scherm getoond wordt.
            // open het correcte scherm (paypol, bancontact of visa)
            // Toon in message box of het gelukt is.
        }
    }
}
