using System;

namespace Napilnik
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order(id: 12345678, amount: 12000);

            //Выведите платёжные ссылки для трёх разных систем платежа: 

            //pay.system1.ru/order?amount=12000RUB&hash={MD5 хеш ID заказа}
            var paymentSystem1 = new PaymentSystem1(
                new DomainName(firstLevel: "ru", secondLevel: "system1", thirdLevel: "pay", pathSegment: "order"), 
                new HashMD5());

            Console.WriteLine(paymentSystem1.GetPaymentLink(order));

            Console.WriteLine();

            //order.system2.ru/pay?hash={MD5 хеш ID заказа + сумма заказа}
            var paymentSystem2 = new PaymentSystem2(
                new DomainName(firstLevel: "ru", secondLevel: "system2", thirdLevel: "order", pathSegment: "pay"), 
                new HashMD5());

            Console.WriteLine(paymentSystem2.GetPaymentLink(order));

            Console.WriteLine();

            //system3.com/pay?amount=12000&curency=RUB&hash={SHA-1 хеш сумма заказа + ID заказа + секретный ключ от системы}
            var secretKey = "4950NDSBV384NMSHS7X2M9";
            var paymentSystem3 = new PaymentSystem3(
                new DomainName(firstLevel: "com", secondLevel: "system3", pathSegment: "pay"), 
                secretKey, 
                new HashSHA1());

            Console.WriteLine(paymentSystem3.GetPaymentLink(order));

            Console.ReadKey();
        }
    }
}
