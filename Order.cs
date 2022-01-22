using System;

namespace Napilnik
{
    public class Order
    {
        public readonly int Id;
        public readonly int Amount;

        public Order(int id, int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            Id = id;
            Amount = amount;
        }
    }
}
