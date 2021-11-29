using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik.Source.Task2
{
    public class Cart
    {
        private readonly Warehouse _warehouse;
        private Dictionary<Product, int> _products = new Dictionary<Product, int>();
        private Order _order = new Order();

        public Cart(Warehouse warehouse)
        {
            if (warehouse == null)
                throw new ArgumentNullException(nameof(warehouse));

            _warehouse = warehouse;
        }

        public IReadOnlyDictionary<Product, int> Products => _products;

        public void Add(Product product, int count)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            _warehouse.DeliverFrom(product, count);

            if (_products.ContainsKey(product))
                _products[product] += count;
            else
                _products.Add(product, count);    
        }

        public Order CreateOrder()
        {
            return new Order();
        }
    }
}