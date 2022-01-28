using System;
using UnityEngine;

namespace Napilnik.Source
{
    public class Player
    {
        public Player(int health, int maxHealth)
        {
            if (health <= 0)
                throw new ArgumentOutOfRangeException(nameof(health));

            if (maxHealth <= 0 || maxHealth < health)
                throw new ArgumentOutOfRangeException(nameof(maxHealth));

            Health = health;
            MaxHealth = maxHealth;
        }

        public int Health { get; private set; }
        public int MaxHealth { get; private set; }

        public void ApplyDamage(int damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            int expectedHealth = Health - damage;

            Health = Mathf.Clamp(expectedHealth, 0, MaxHealth);
        }
    }
}