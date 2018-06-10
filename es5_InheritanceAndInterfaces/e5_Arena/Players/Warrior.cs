using System;
using System.Collections.Generic;
using System.Text;

namespace e5_Arena.Players
{
    class Warrior : Player
    {
        public Warrior(string epicName, double pV, Speed speed)
            : base(epicName, pV, speed)
        { }

        public double DamagePercentage(Player enemy)
        {
            double damage;

            if (enemy.PV > 5)
                damage = 5;

            else
            {
                damage = enemy.PV * 10 / 100;
            }

            return damage;
        }
    }
}
