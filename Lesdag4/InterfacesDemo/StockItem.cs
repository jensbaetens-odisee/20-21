using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class StockItem
    {
        string name;
        double price;

        public StockItem(string name, double price)
        {
            this.name = name;
            this.price = price;
        }

        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }

        public override string ToString()
        {
            return $"{name} - €{price}";
        }
    }
}
