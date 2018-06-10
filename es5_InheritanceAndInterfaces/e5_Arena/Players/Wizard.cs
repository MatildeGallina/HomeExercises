using System;
using System.Collections.Generic;
using System.Text;

namespace e5_Arena.Players
{
    class Wizard : Player
    {
        public Wizard(string epicName, double pV, Speed speed)
            : base(epicName, pV, speed)
        { }

        public double MaximumPower(Player enemy)
        {
            Random rand = new Random();
            double r = rand.NextDouble();

            double damage = enemy.PV * r;

            return damage;
        }
    }
}
