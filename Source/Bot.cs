using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik.Source
{
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
}