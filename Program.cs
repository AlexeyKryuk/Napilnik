using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napilnik
{
    class CleanCode_ExampleTask11
    {
        private readonly int _armySize;
        private readonly int _coinsNumber;
        private readonly string _name;

        public CleanCode_ExampleTask11(int armySize, int coinsNumber, string name)
        {
            if (armySize < 0)
                throw new ArgumentOutOfRangeException(nameof(armySize));

            if (coinsNumber < 0)
                throw new ArgumentOutOfRangeException(nameof(coinsNumber));

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(name);

            _armySize = armySize;
            _coinsNumber = coinsNumber;
            _name = name;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
