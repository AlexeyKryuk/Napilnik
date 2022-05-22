using System;

namespace Napilnik.Source
{
    public class Health : IReadOnlyHealth
    {
        private int _value;
        private int _maxValue;

        public Health(int value, int maxValue)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            if (maxValue <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxValue));

            _value = value;
            _maxValue = maxValue;
        }

        public int Value => _value;
        public int MaxValue => _maxValue;

        public void ApplyDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            _value -= damage;
        }
    }

    public interface IReadOnlyHealth
    {
        int Value {get; }
        int MaxValue {get; }
    }
}
