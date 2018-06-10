using System;
using System.Collections.Generic;
using System.Text;

namespace e5_Arena.Players
{
    class Ork : Player
    {
        public Ork(string epicName, double pV, Speed speed)
            : base(epicName, pV, speed)
        { }

        public double Strength()
        {
            double damage = 9;
            return damage;
        }
    }
}
