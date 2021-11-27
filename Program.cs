using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Weapon
    {
        public Weapon(int damage, int bullets)
        {
            if (damage < 0 || bullets < 0)
                throw new ArgumentOutOfRangeException();

            Damage = damage;
            Bullets = bullets;
        }

        public event Action BulletsEnded;
        public int Damage { get; private set; }
        public int Bullets { get; private set; }

        public void Fire(Player player)
        {
            if (player == null)
                throw new ArgumentNullException();

            if (Bullets == 0)
            {
                BulletsEnded?.Invoke();
            }
            else
            {
                Bullets--;
                player.ApplyDamage(Damage);
            }
        }
    }

    public class Bot
    {
        public Bot(Weapon weapon)
        {
            if (weapon == null)
                throw new ArgumentNullException();

            Weapon = weapon;
        }

        public Weapon Weapon { get; private set; }

        public void OnSeePlayer(Player player)
        {
            Weapon.Fire(player);
        }
    }

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
