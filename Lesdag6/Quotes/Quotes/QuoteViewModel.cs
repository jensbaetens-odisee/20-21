using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quotes
{
    class QuoteViewModel
    {
        public List<Quote> Quotes { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }

        public QuoteViewModel()
        {

        }
    }
}
