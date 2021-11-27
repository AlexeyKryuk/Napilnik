using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik.Source
{
    public class Player
    {
        public Player(int health)
        {
            if (health <= 0)
                throw new ArgumentOutOfRangeException();

            Health = health;
        }

        public event Action HealthEnded;
        public event Action<int> HealthChanged;

        public int Health { get; private set; }

        public void ApplyDamage(int damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException();

            int expectedHealth = Health - damage;

            if (expectedHealth < 0)
            {
                Health = 0;
                HealthEnded?.Invoke();
            }
            else
            {
                Health = expectedHealth;
                HealthChanged?.Invoke(Health);
            }
        }
    }
}