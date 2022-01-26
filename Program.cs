using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    struct Vector2
    {
        public float X { get; private set; }
        public float Y { get; private set; }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
    }

    class Movement
    {
        public Vector2 Direction { get; private set; }
        public float Speed { get; private set; }

        public void Move()
        {
            //Do move
        }
    }

    class Weapon
    {
        public float Cooldown { get; private set; }
        public int Damage { get; private set; }

        public void Attack()
        {
            //Attack
        }

        public bool IsReloading()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
