using System;

namespace Napilnik.Source
{
    public class Bot
    {
        private readonly Weapon _weapon;
        
        public Bot(Weapon weapon)
        {
            if (weapon == null)
                throw new ArgumentNullException(nameof(weapon));

            _weapon = weapon;
        }

        public void OnSeePlayer(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            _weapon.Fire(player);
        }
    }
}