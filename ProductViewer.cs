using System;
using System.Collections.Generic;

namespace Napilnik.Source.Task2
{
    public class ProductViewer
    {
        public void DisplayAll(IReadOnlyDictionary<Product, int> products)
        {
            if (products == null)
                throw new ArgumentNullException(nameof(products));

            Console.WriteLine("--------Остаток товаров на складе--------");

            foreach (var product in products)
                Console.WriteLine(product.Key.Name + ": " + product.Value);

            Console.ReadKey();
        }
    }
}
