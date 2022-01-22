using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    public interface IPaymentLinkGenerator
    {
        string GetPaymentLink(Order order);
    }

    public abstract class PaymentSystem : IPaymentLinkGenerator
    {
        private readonly DomainName _domainName;
        private readonly Hash _hash;

        protected PaymentSystem(DomainName domainName, Hash hash)
        {
            if (hash == null)
                throw new ArgumentNullException(nameof(hash));

            _domainName = domainName;
            _hash = hash;
        }

        protected string CalculateHash(Order order)
        {
            return _hash.Create(GetHashInput(order));
        }

        public string GetPaymentLink(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            var parameters = GetLinkParameters(order);
            var domainName = _domainName.GetName();

            var link = $"{domainName}{parameters}";

            return link;
        }

        protected abstract string GetLinkParameters(Order order);

        protected abstract string GetHashInput(Order order);
    }

    public class PaymentSystem1 : PaymentSystem
    {
        public PaymentSystem1(DomainName domainName, Hash hash) : base(domainName, hash) { }

        protected override string GetLinkParameters(Order order)
        {
            var hash = CalculateHash(order);
            return $"amount={order.Amount}RUB&hash={hash}";
        }

        protected override string GetHashInput(Order order)
        {
            return order.Id.ToString();
        }
    }

    public class PaymentSystem2 : PaymentSystem
    {
        public PaymentSystem2(DomainName domainName, Hash hash) : base(domainName, hash) { }

        protected override string GetLinkParameters(Order order)
        {
            var hash = CalculateHash(order);
            return $"hash={hash}";
        }

        protected override string GetHashInput(Order order)
        {
            return (order.Id + order.Amount).ToString();
        }
    }

    public class PaymentSystem3 : PaymentSystem
    {
        private string _secretKey;

        public PaymentSystem3(DomainName domainName, string secretKey, Hash hash) : base(domainName, hash)
        {
            _secretKey = secretKey;
        }

        protected override string GetLinkParameters(Order order)
        {
            var hash = CalculateHash(order);
            return $"amount={order.Amount}&currency=RUB&hash={hash}";
        }

        protected override string GetHashInput(Order order)
        {
            return order.Id.ToString() + order.Amount.ToString() + _secretKey;
        }
    }
}
