using System;

namespace e8_Tria
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Un progetto Console permette di giocare a Tria.
             * Creare una classe `TriaGame` per gestire l'interazione tra i giocatori e il calcolo del vincitore.
             * Questa classe accetta all'inizio due istanze di `IPlayer`. Questa interfaccia definisce solo la
             * scelta di una casella libera, avendo in input la matrice del gioco.
             * A implementare questa interfaccia sono due classi:
             * - `PersonPlayer`, che rappresenta un giocatore reale; in questo caso quale casella scegliere viene 
             * chiesto all'utente in `Console`;
             * - `ComputerPlayer`, che invece sceglie una casella libera a caso.
             * Nel `Main()` istanziare i due player e il gioco, e far partire il gioco.
             * Ad ogni mossa fatta da uno dei due giocatori, ristampare in Console la situazione corrente del gioco.
             * Il `TriaGame`, ad ogni turno del giocatore, a fine mossa deve controllare se c'è una tria fatta, in
             * quel caso deve interrompere il gioco e stampare il nome del vincitore.
             */

            TriaGame game = new TriaGame();

            PersonPlayer p1 = new PersonPlayer("Gino", "x");
            PersonPlayer p2 = new PersonPlayer("Toni", "o");

            game.StartGame(p1, p2);

            Console.Read();
        }
    }
}
