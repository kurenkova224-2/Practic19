using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic19_2
{
    internal class ProductOutOfStock : Exception
    {
        public string ProductName { get; }
        public int RemainingQuantity { get; }

        public ProductOutOfStock(string productName, int remainingQuantity)
            : base($"Товар {productName} закончился! Осталось: {remainingQuantity}")
        {
            ProductName = productName;
            RemainingQuantity = remainingQuantity;
        }
    }
}
