using System;
using System.Collections.Generic;
using System.Text;

namespace e5_Arena.Players
{
    class Player
    {

        public Player(string epicName, double pV, Speed speed)
        {
            EpicName = epicName;
            PV = pV;
            Sp = speed;
        }

        public string EpicName { get; set; }
        public double PV { get; set; }
        public Speed Sp { get; set; }
    }

    enum Speed
    { 
        livello1,
        livello2,
        livello3,
        livello4,
        livello5,
        livello6,
        livello7,
        livello8,
        livello9,
        livello10
    }
}
