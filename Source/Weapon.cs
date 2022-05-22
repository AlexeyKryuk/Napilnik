using System;

namespace Napilnik.Source
{
    public class Weapon
    {
        private int _bulletsPerShoot;
        private int _damage;
        private int _bullets;
        
        public Weapon(int damage, int bullets, int bulletsPerShoot = 1)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (bullets < 0)
                throw new ArgumentOutOfRangeException(nameof(bullets));
                
            if (bulletsPerShoot < 0)
                throw new ArgumentOutOfRangeException(nameof(bulletsPerShoot));

            _damage = damage;
            _bullets = bullets;
            _bulletsPerShoot = bulletsPerShoot;
        }

        public bool CanShoot => _bullets >= _bulletsPerShoot;

        public void Fire(Player player)
        {
            if (CanShoot == false)
                throw new InvalidOperationException(nameof(CanShoot));

            Bullets -= _bulletsPerShoot;
            player.ApplyDamage(Damage);
        }
    }
}
