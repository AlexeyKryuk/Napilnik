using System;

namespace Napilnik.Source
{
    public class Player
    {
        public Player(int health)
        {
            if (health <= 0)
                throw new ArgumentOutOfRangeException(nameof(health));

            Health = health;
        }

        public int Health { get; private set; }

        public void ApplyDamage(int damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            int expectedHealth = Health - damage;

            Health = Math.Max(expectedHealth, 0);
        }
    }
}