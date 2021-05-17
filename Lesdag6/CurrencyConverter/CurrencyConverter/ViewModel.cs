using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CurrencyConverter
{
    class ViewModel
    {
        private Currency[] currencies = (Currency[])Enum.GetValues(typeof(Currency));

        public Currency[] AllCurrencies { get => currencies; set {
                currencies = value;
                OnPropertyChanged();
            } 
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // hier moet iets staan om het event te versturen, zie slides
        }

        public ICommand ConvertCurrencyCommand { get; private set; }

        public Currency SelectedFromCurrency { get;set;}
        public Currency SelectedToCurrency { get; set; }
        public double FromCurrency { get; set; }
        public double ToCurrency { get; set; }

        public ViewModel()
        {
            ConvertCurrencyCommand = new CurrencyConverterCommand(ConvertCurrency);
            currencies = new Currency[]{ };
        }

        public void ConvertCurrency()
        {
            ToCurrency = 1.0;
        }
    }
}
