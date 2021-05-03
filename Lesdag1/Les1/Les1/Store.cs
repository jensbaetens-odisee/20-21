using System;
using System.Collections.Generic;
using System.Text;

namespace Les1
{
    public class Store
    {
        private Dictionary<Product, int> inventory = new Dictionary<Product, int>();

        public void AddInventory(Product product, int q)
        {
            if (inventory.ContainsKey(product))
            {
                inventory[product] += q;
            } else
            {
                inventory.Add(product, q);
            }
        }

        public void RemoveInventory(Product product, int q)
        {
            inventory[product] -= q;
        }

        public int GetInventory(Product product)
        {
            return inventory[product];
        }

        public bool HasInventory(Product product, int q)
        {
            return inventory[product] >= q;
        }
    }
}
