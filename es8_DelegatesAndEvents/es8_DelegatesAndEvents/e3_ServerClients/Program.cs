using System;
using System.Collections.Generic;
using System.Linq;

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
            MyServer server1 = new MyServer("1");
            MyClient client1 = new MyClient("1");
            MyClient client2 = new MyClient("2");

            server1.Notification += client1.SentNotification;

            server1.ReceivedNotification(client1, "File salvato");

            Console.Read();
        }
    }

    delegate void NotificationHandler(string message);

    class MyServer
    {
        public MyServer(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public event NotificationHandler Notification;

        public void ReceivedNotification(MyClient myClient, string message)
        {
            Console.WriteLine($"Server {Name} received a notification from {myClient.Name}.");
            //Notification(this);
            // è lo stesso di
            Notification.Invoke(message);
        }
    }

    class MyClient
    {
        public MyClient(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void SentNotification(string message)
        {
            Console.WriteLine($"Client {Name} sent a notification to the server: ");
            Console.WriteLine(message);
        }
    }
}
    
