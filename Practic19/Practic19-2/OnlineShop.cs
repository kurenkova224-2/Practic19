using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic19_2
{
    internal class OnlineShop
    {
        private Dictionary<string, int> _inventory;

        public OnlineShop()
        {
            _inventory = new Dictionary<string, int>();
        }

        public void AddProduct(string product, int quantity)
        {
            if (_inventory.ContainsKey(product))
            {
                _inventory[product] += quantity;
            }
            else
            {
                _inventory[product] = quantity;
            }
        }

        public void Buy(string product, int quantity)
        {
            Console.WriteLine($"Покупаем {product} - {quantity} шт.");

            if (!_inventory.ContainsKey(product) || _inventory[product] < quantity)
            {
                int remainingQuantity = _inventory.ContainsKey(product) ? _inventory[product] : 0;
                throw new ProductOutOfStock(product, remainingQuantity);
            }

            _inventory[product] -= quantity;
            Console.WriteLine($"Покупка успешна! Осталось {product}: {_inventory[product]} шт.");
        }
    }
}
