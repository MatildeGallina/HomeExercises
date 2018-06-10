using System;

namespace e3_AskedMoneyFrom
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Provare ad estendere l'esercizio sulle varie `Person` con metodo `AskedMoneyFrom`, derivando
             * la `Person` in nuove classi come ad esempio una `NunPerson`, `RichPerson`, ecc, implementando
             * modi nuovi di "dare soldi".
             */

            RichPerson mario = new RichPerson("Mario", 9000, 500, 0);
            RichPerson luigi = new RichPerson("Luigi", 5000, 100, 0);
            NunPerson toni = new NunPerson("Toni", 50, 100, 0);
            NunPerson beppe = new NunPerson("Beppe", 10, 5, 0);

            Console.WriteLine("Situazione iniziale:");
            Console.WriteLine($"{mario.Name} - {mario.Money} euro.");
            Console.WriteLine($"{luigi.Name} - {luigi.Money} euro.");
            Console.WriteLine($"{toni.Name} - {toni.Money} euro.");
            Console.WriteLine($"{beppe.Name} - {beppe.Money} euro.");

            toni.AskMoney(luigi);
            beppe.AskMoney(mario);

            luigi.AskedMoneyFrom(toni);
            mario.AskedMoneyFrom(beppe);

            Console.WriteLine($"{mario.Name} - {mario.Money} euro.");
            Console.WriteLine($"{luigi.Name} - {luigi.Money} euro.");
            Console.WriteLine($"{toni.Name} - {toni.Money} euro.");
            Console.WriteLine($"{beppe.Name} - {beppe.Money} euro.");

            Console.ReadLine();
        }
    }
}
