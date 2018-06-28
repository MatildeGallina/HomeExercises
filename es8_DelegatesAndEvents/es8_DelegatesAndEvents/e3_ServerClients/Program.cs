using System;

namespace e3_ServerClients
{
    class Program
    {
        /* Una classe `Server` ha un evento per inviare messaggi.
         * Una classe `Client` ha uno o più metodi per gestire tali messaggi.
         * Generare le due classi, il delegate dell'evento, l'evento sul `Server`, e i metodi sul `Client`.
         * Provare nel `Main()` ad agganciare e sganciare alcuni `Client` dal `Server`, e verificare il corretto funzionamento.
         */

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Server
    {
        public event Func<string, string> NewMessage;
    }
}
