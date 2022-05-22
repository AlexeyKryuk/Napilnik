using System;

namespace Napilnik.Source
{
    public struct Health : IReadOnlyHealth
    {
        private int _value;
        private int _maxValue;

        public Health(int value, int maxValue)
        {
            if (value < 0 || value > maxValue)
                throw new ArgumentOutOfRangeException(nameof(value));

            if (maxValue < 1)
                throw new ArgumentOutOfRangeException(nameof(maxValue));

            _value = value;
            _maxValue = maxValue;
        }

        public int Value => _value;
        public int MaxValue => _maxValue;

        public Health TakeDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            return new Health(Math.Max(_value - damage, 0), _maxValue);
        }
    }

    public interface IReadOnlyHealth
    {
        int Value { get; }
        int MaxValue { get; }
    }
}
