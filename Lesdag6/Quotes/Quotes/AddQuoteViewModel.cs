using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotes
{
    public class AddQuoteViewModel
    {
        private string author = "";
        private string text = "";

        public string Author
        {
            get => author; set
            {
                author = value;
            }
        }
        public string Text
        {
            get => text; set
            {
                text = value;
            }
        }

        public ICommand CreateQuoteCommand { get; set; }
        private ICoordinator coordinator;
        private ICloseable closeable;
        private IQuoteRepository repository;


        public AddQuoteViewModel(ICoordinator coordinator, ICloseable closeable)
            : this(coordinator, closeable, new QuoteRepository())
        {
        }

        public AddQuoteViewModel(ICoordinator coordinator, ICloseable closeable, IQuoteRepository repository)
        {
            CreateQuoteCommand = new RelayCommand(CreateQuote);
            this.coordinator = coordinator;
            this.closeable = closeable;
            this.repository = repository;
        }

        private void CreateQuote()
        {
            if (!string.IsNullOrEmpty(Text) && !string.IsNullOrEmpty(Author))
            {
                Quote quote = new Quote(Text, Author);
                repository.AddQuote(quote);
                closeable.Close();
            }
            else
            {
                coordinator.ShowDialog("Vul alle gegevens in");
            }
        }        
    }
}
