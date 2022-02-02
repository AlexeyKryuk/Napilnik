using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public abstract class PaymentSystem
    {
        protected readonly PaymentSystemLogger _logger;
        protected readonly string _systemID;

        public PaymentSystem(string systemID, PaymentSystemLogger logger)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));

            if (string.IsNullOrEmpty(systemID))
                throw new ArgumentNullException(systemID);

            _systemID = systemID;
            _logger = logger;
        }

        public string SystemID => _systemID;

        public void Pay()
        {
            PayLogic();
        }

        public void Verify()
        {
            VerifyLogic();
        }

        protected abstract void PayLogic();
        protected abstract void VerifyLogic();
    }

    public class QiwiPaymentSystem : PaymentSystem
    {
        public QiwiPaymentSystem(string systemID, PaymentSystemLogger logger) : base(systemID, logger)
        {
        }

        protected override void PayLogic()
        {
            _logger.LogPayment();
        }

        protected override void VerifyLogic()
        {
            _logger.LogVerification(_systemID);
        }
    }

    public class WebMoneyPaymentSystem : PaymentSystem
    {
        public WebMoneyPaymentSystem(string systemID, PaymentSystemLogger logger) : base(systemID, logger)
        {
        }

        protected override void PayLogic()
        {
            _logger.LogPayment();
        }

        protected override void VerifyLogic()
        {
            _logger.LogVerification(_systemID);
        }
    }

    public class CardPaymentSystem : PaymentSystem
    {
        public CardPaymentSystem(string systemID, PaymentSystemLogger logger) : base(systemID, logger)
        {
        }

        protected override void PayLogic()
        {
            _logger.LogPayment();
        }

        protected override void VerifyLogic()
        {
            _logger.LogVerification(_systemID);
        }
    }
}
