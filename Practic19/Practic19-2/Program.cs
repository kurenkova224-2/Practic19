using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic19_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OnlineShop shop = new OnlineShop();
            shop.AddProduct("iPhone", 5);

            try
            {
                shop.Buy("iPhone", 2); // Покупаем 2 iPhone
                shop.Buy("iPhone", 4); // Попытка купить 4 iPhone, что вызовет исключение
            }
            catch (ProductOutOfStock ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
