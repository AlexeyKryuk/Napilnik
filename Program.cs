using Napilnik.Source.Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik.Source.Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Product iPhone12 = new Product("IPhone 12");
            Product iPhone11 = new Product("IPhone 11");

            Warehouse warehouse = new Warehouse();

            Shop shop = new Shop(warehouse);
            warehouse.DisplayRemainder();

            warehouse.DeliverTo(iPhone12, 10);
            warehouse.DeliverTo(iPhone11, 1);

            warehouse.DisplayRemainder();
            //Вывод всех товаров на складе с их остатком

            Cart cart = shop.GetCart();
            cart.Add(iPhone12, 4);
            cart.Add(iPhone11, 3); //при такой ситуации возникает ошибка так, как нет нужного количества товара на складе

            //Вывод всех товаров в корзине
            warehouse.DisplayRemainder();

            Console.WriteLine(cart.CreateOrder().Paylink);

            cart.Add(iPhone12, 9); //Ошибка, после заказа со склада убираются заказанные товары
        }
    }
}
