using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik.Source.Task2
{
    public class Warehouse
    {
        private Dictionary<Product, int> _products = new Dictionary<Product, int>();

        public IReadOnlyDictionary<Product, int> Products => _products;

        public void DeliverTo(Product product, int count)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (_products.ContainsKey(product))
                _products[product] += count;
            else
                _products.Add(product, count);
        }

        public void DeliverFrom(Product product, int count)
        {
            int availability = CheckAvailability(product, count);
            int countInWarehouse = _products[product];
            int expectedCount = count;

            switch (availability)
            {
                case 1:
                    _products[product] = countInWarehouse - expectedCount;
                    if (_products[product] == 0)
                        _products.Remove(product);
                    break;
                case 0:
                    throw new ArgumentOutOfRangeException(nameof(count));
                case -1:
                    throw new ArgumentOutOfRangeException(nameof(product));
                default:
                    throw new ArgumentOutOfRangeException(nameof(availability));
            }
        }

        public void DisplayRemainder()
        {
            Console.WriteLine("--------Остаток на складе--------");

            foreach (var product in _products)
            {
                Console.WriteLine(product.Key.Name + ": " + product.Value);
            }

            Console.ReadKey();
        }

        private int CheckAvailability(Product product, int count)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (_products.ContainsKey(product) && _products[product] >= count)
                return 1;
            else if (_products.ContainsKey(product) && _products[product] < count)
                return 0;
            else
                return -1;
        }
    }
}