using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public class PaymentHandler
    {
        public void ShowPaymentResult(IEnumerable<PaymentSystem> paymentSystems, string systemID)
        {
            try
            {
                PaymentSystem selectedPaymentSystem = paymentSystems.Where(system => system.SystemID == systemID).First();

                selectedPaymentSystem.Pay();
                selectedPaymentSystem.Verify();
            }
            catch (Exception)
            {
                Console.WriteLine("Такой платежной системы нет");
            }
        }
    }
}
