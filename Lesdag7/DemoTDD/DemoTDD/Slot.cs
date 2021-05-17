using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTDD
{
    public class Slot
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int SlotNumber { get; set; }

        public Slot(string name, double price, int quantity, int slotNumber)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            SlotNumber = slotNumber;
        }
    }
}
