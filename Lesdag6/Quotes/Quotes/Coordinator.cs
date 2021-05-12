using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Quotes
{
    class Coordinator : ICoordinator
    {
        // Maak interface voor coordinator met showMainWindow
        // Deze klasse gemaakt waar het mainwindow en viewmodel gemaakt wordt
        // Geef de coordinator mee met de constructor van het viewmodel zodat die andere views kan openen
        // Zorg ervoor dat mainWindow niet automatisch wordt opgestart, dit is zodat de coordinator ertussen kan zitten
        // Ander had je ViewModel MessageBox.Show();

        public void ShowMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            QuoteViewModel viewModel = new QuoteViewModel(this, mainWindow);
            mainWindow.DataContext = viewModel; // link between view en viewmodel

            mainWindow.Show();
        }

        public void ShowQuoteWindow()
        {
            AddQuoteWindow aqw = new AddQuoteWindow();
            AddQuoteViewModel aqvm = new AddQuoteViewModel(this, aqw);
            aqw.DataContext = aqvm;

            aqw.Show();
        }

        public void ShowDialog(string message)
        {
            MessageBox.Show(message);
        }
    }
}
