using System;
using System.Collections.Generic;
using System.Text;

namespace Les1
{
    public class Customer
    {
        private Dictionary<Product, int> basket = new Dictionary<Product, int>();

        public Dictionary<Product, int> Basket { get => basket; private set => basket = value; }

        public bool Purchase(Store store, Product product, int quantity)
        {
            if(store.HasInventory(product, quantity))
            {
                store.RemoveInventory(product, quantity);
                basket.Add(product, quantity);
                return true;
            }

            return false;
        }

    }
}
