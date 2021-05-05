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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bmi_calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void userListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void addButtonClicked(object sender, RoutedEventArgs e)
        {
            User user = new User();

            //find name
            user.Name = nameTextBox.Text;

            //find birthdate
            user.BirthDate = (DateTime)birtDatePicker.SelectedDate;

            //add user to database
            UserRepository userRepository = new UserRepository();
            try { 
                userRepository.AddUser(user);
                userListBox.Items.Add(user.Name);
            }
            catch
            {

            }
        }

        private void userListBoxInitialized(object sender, EventArgs e)
        {
            UserRepository userRepository = new UserRepository();
            foreach(var user in userRepository.GetUsers())
            {
                userListBox.Items.Add(user.Name);
            }
        }
    }
}
