using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Quotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IQuoteRepository quoteRepository;
        public MainWindow() : this(new QuoteRepository())
        {

        }

        public MainWindow(IQuoteRepository quoteRepository)
        {
            InitializeComponent();
            this.quoteRepository = quoteRepository;
            LoadQuotes();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (authorTextBox.Text != String.Empty && quoteTextBox.Text != String.Empty)
            {
                Quote quote = new Quote(quoteTextBox.Text, authorTextBox.Text);
                quoteRepository.AddQuote(quote);
            }
            else
            {
                MessageBox.Show("error");
            }
            LoadQuotes();
        }

        private void LoadQuotes()
        {
            quotesListBox.Items.Clear();
            List<Quote> quotes = quoteRepository.GetAllQuotes();

            foreach (Quote quote in quotes)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = quote.Text;
                listBoxItem.Tag = quote.Id;

                quotesListBox.Items.Add(listBoxItem);
            }
        }
        public ListBox QuotesListBox { get => quotesListBox; }
        public TextBox AuthorTextBox { get => authorTextBox; }
        public TextBox QuoteTextBox { get => quoteTextBox; }

        public void quotesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (quotesListBox.SelectedIndex != -1)
            {
                ListBoxItem selectedListBoxItem = (ListBoxItem)quotesListBox.SelectedItem;
                Quote quote = quoteRepository.GetQuote((int)selectedListBoxItem.Tag);

                authorTextBox.Text = quote.Author;
                quoteTextBox.Text = quote.Text;
            } else
            {
                authorTextBox.Text ="";
                quoteTextBox.Text = "";
            }
        }
    }
}
