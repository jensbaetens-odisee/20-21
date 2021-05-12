using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotes
{
    //stap 1: link met binding de properties aan de listbox en txtboxes
    //stap 2: Commando aangemaakt voor de save knop
    //stap 3: Notificatie gaan sturen zodat de listbox geupdate wordt. (ObservableCollection)
    //stap 4: Ervoor zorgen dat als er in de listbox selectie veranderd,
    //  dat de tekstveldjes geupdate worden (INotifyPropertyChanged en PropertyChanged())
    //stap 5: Beetje PropertyChanged opkuisen
    //stap 6: Unit testing
    //stap 7: Coordinator pattern

    public class QuoteViewModel : INotifyPropertyChanged
    {
        private string author = "";
        private string text = "";

        public ObservableCollection<Quote> Quotes { get; set; }
        public string Author { get => author; set
            {
                author = value;
                //PropertyChanged(this, new PropertyChangedEventArgs("Author"));
                OnPropertyChanged();
            } 
        }
        public string Text
        {
            get => text; set
            {
                text = value;
                //PropertyChanged(this, new PropertyChangedEventArgs("Text"));
                OnPropertyChanged();

            }
        }

        public Quote SelectedQuote { set
            {
                ShowSelectedQuote(value);
            } 
        }
        
        public ICommand CreateQuoteCommand { get; set; }
        private ICoordinator coordinator;
        private ICloseable closeable;
        private IQuoteRepository repository;

        public QuoteViewModel(ICoordinator coordinator, ICloseable closeable)
            :this(coordinator, closeable, new QuoteRepository())
        {
        }

        public QuoteViewModel(ICoordinator coordinator, ICloseable closeable, IQuoteRepository repository)
        {
            Quotes = new ObservableCollection<Quote>();
            CreateQuoteCommand = new RelayCommand(CreateQuote);
            this.coordinator = coordinator;
            this.closeable = closeable;
            this.repository = repository;
            LoadQuotes();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void CreateQuote()
        {
            coordinator.ShowQuoteWindow();
            LoadQuotes();
            /*if(!string.IsNullOrEmpty(Text) && !string.IsNullOrEmpty(Author)) { 
                Quote quote = new Quote(Text, Author);
                Quotes.Add(quote); 
                coordinator.ShowDialog("New quote added");
            } else {
                coordinator.ShowDialog("Vul alle gegevens in");
            }*/
        }

        public void LoadQuotes()
        {
            List<Quote> quotes = repository.GetAllQuotes();
            Quotes.Clear();
            foreach(var quote in quotes)
            {
                Quotes.Add(quote);
            }
        }

        private void ShowSelectedQuote(Quote selectedQuote)
        {
            Text = selectedQuote.Text;
            Author = selectedQuote.Author;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if(PropertyChanged!= null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
