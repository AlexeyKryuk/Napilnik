using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public class OrderForm
    {
        public string ShowForm(IEnumerable<PaymentSystem> paymentSystems)
        {
            string output = "Мы принимаем: ";
            string separator = ", ";

            foreach (var system in paymentSystems)
                output = output + system.SystemID + separator;

            output = output.Remove(output.Length - separator.Length);
            Console.WriteLine(output);

            Console.WriteLine("Какой системой вы хотите совершить оплату?");
            return Console.ReadLine();
        }
    }
}
