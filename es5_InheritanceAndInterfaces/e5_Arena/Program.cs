using System;
using System.Collections.Generic;
using e5_Arena.Players;

namespace e5_Arena
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior hercules = new Warrior("Hercules", 150, Speed.livello9);
            Warrior leonida = new Warrior("Leonida", 105, Speed.livello6);
            Warrior bjorn = new Warrior("Bjorn", 120, Speed.livello8);

            Wizard dumbledore = new Wizard("Dumbledore", 115, Speed.livello8);
            Wizard voldemort = new Wizard("Lord Voldemort", 160, Speed.livello10);

            Ork azog = new Ork("Azog", 130, Speed.livello5);
            Ork bolg = new Ork("Bolg", 89, Speed.livello3);

            List<Player> players = new List<Player>
            {
                hercules,
                leonida,
                bjorn,
                dumbledore,
                voldemort,
                azog,
                bolg
            };

            // Trovare il massimo a partire da index = 0 e metterlo primo in lista
            // index++

            for (int count = 0; count < players.Count; count++)
            {
                Player pWithMaxSpeed = players[count];
                for(int index = players.Count; index >= count; index--)
                {
                    if (players[index].Sp > players[index - 1].Sp)
                        pWithMaxSpeed = players[index];
                }
                players.Insert(count, pWithMaxSpeed);
            }

            Arena a = new Arena();
            a.StartGame();

            Console.ReadLine();
        }
    }
}
