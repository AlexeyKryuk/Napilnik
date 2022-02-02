using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public interface ILogger
    {
        void Log(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class PaymentSystemLogger
    {
        private readonly ILogger _logger;
        protected readonly string _paymentLog;
        protected readonly string _verificationLog;

        public PaymentSystemLogger(ILogger logger, string paymentLog, string verificationLog)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            _logger = logger;
            _paymentLog = paymentLog;
            _verificationLog = verificationLog;
        }

        public void LogPayment()
        {
            _logger.Log(_paymentLog);
        }

        public void LogVerification(string systemID)
        {
            string message = $"Вы оплатили с помощью {systemID}\n{_verificationLog}\nОплата прошла успешно!";
            _logger.Log(message);
        }
    }
}
