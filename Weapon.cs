using System;

namespace Napilnik.Source
{
    public class Weapon
    {
        public Weapon(int damage, int bullets)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (bullets < 0)
                throw new ArgumentOutOfRangeException(nameof(bullets));

            Damage = damage;
            Bullets = bullets;
        }

        public event Action BulletsEnded;
        public int Damage { get; private set; }
        public int Bullets { get; private set; }

        public void Fire(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

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
}
