using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class Program
    {
        class Weapon
        {
            private readonly int _bulletsPerShot;
            private int _bullets;

            public Weapon(int bulletsPerShot, int bullets)
            {
                if (bulletsPerShot <= 0)
                    throw new ArgumentOutOfRangeException(nameof(bulletsPerShot));

                if (bullets < 0)
                    throw new ArgumentOutOfRangeException(nameof(bullets));

                _bulletsPerShot = bulletsPerShot;
                _bullets = bullets;
            }

            public bool CanShoot() => _bullets >= _bulletsPerShot;

            public void Shoot() => _bullets -= _bulletsPerShot;
        }

        static void Main(string[] args)
        {

        }
    }
}
