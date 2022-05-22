using System;

namespace Napilnik.Source
{
    public class Player
    {
        private Health _health;

        public Player(int health)
        {
            if (health <= 0)
                throw new ArgumentOutOfRangeException(nameof(health));

            _health = health;
        }

        public IReadOnlyHealth Health => _health;

        public void ApplyDamage(int damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            _health.ApplyDamage(damage);
        }
    }
}