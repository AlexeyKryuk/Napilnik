using System;

namespace Napilnik.Source
{
    public class Player : IDamageable
    {
        private Health _health;

        public Player(Health health)
        {
            _health = health;
        }

        public IReadOnlyHealth Health => _health;

        public event Action<IReadOnlyHealth> HealthChanged;

        public void ApplyDamage(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

           _health = _health.TakeDamage(amount);
            HealthChanged?.Invoke(_health);
        }
    }

    public interface IDamageable
    {
        event Action<IReadOnlyHealth> HealthChanged;

        IReadOnlyHealth Health { get; }

        void ApplyDamage(int amount);
    }
}