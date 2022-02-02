using System;
using System.Collections.Generic;
using System.Linq;

namespace Napilnik
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderForm = new OrderForm();
            var paymentHandler = new PaymentHandler();

            List<PaymentSystem> paymentSystems = new List<PaymentSystem>() { 
                new QiwiPaymentSystem("QIWI", new PaymentSystemLogger(new ConsoleLogger(), "Перевод на страницу QIWI...", "Проверка платежа через QIWI...")),
                new WebMoneyPaymentSystem("WebMoney", new PaymentSystemLogger(new ConsoleLogger(), "Вызов API WebMoney...", "Проверка платежа через WebMoney...")),
                new CardPaymentSystem("Card", new PaymentSystemLogger(new ConsoleLogger(), "Вызов API банка эмитера карты Card...", "Проверка платежа через Card..."))
            };

            string systemID = orderForm.ShowForm(paymentSystems);
            paymentHandler.ShowPaymentResult(paymentSystems, systemID);
        }
    }
}
