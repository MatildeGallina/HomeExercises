using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _4_Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ESERCIZIO 4");

            Console.WriteLine("Creata una lista di numeri primi, stopwatch mi dice quandi millesimi di secondo " +
                "\n\ril compilatore ha impiegato per fare l'operazione");

            Console.Write("Fino che numero vuoi arrivare? ");
            int input1 = ReadSafeFromConsole();

            List<int> list = new List<int>();

            Stopwatch sp = new Stopwatch();
            sp.Start();

            CompilationList(input1, list);

            sp.Stop();

            Console.WriteLine($"Il tempo impiegato è {sp.ElapsedMilliseconds} millisecondi." +
                $"\n\rLa lista contiene {list.Count} elementi.");


            Console.WriteLine("ESERCIZIO 4 BIS");

            Console.WriteLine("Per una lista di n numeri, calcolare i numeri primi" +
                "\n\rper ogni operazione misurare il tempo tempo di esecuzione.");

            Console.Write("Fino a che numero riempio la lista? ");

            int input2 = ReadSafeFromConsole();
            
            List<Pairs> pairs = new List<Pairs>();
            
            for (int i = 2; i <= input2; i++)
            {
                Pairs p = new Pairs();
                p.Number = i;
                pairs.Add(p);
            }
                
            for(int i = 0; i < pairs.Count; i++)
            {
                Pairs current = pairs[i];
                int k = (int)Math.Sqrt(current.Number);
                bool isPrime = true;

                Stopwatch sw = new Stopwatch();
                sw.Start();

                for(int j = 2; j <= k; j++)
                    if (current.Number % j == 0)
                        isPrime = false;

                sw.Stop();

                current.Time = sw.ElapsedMilliseconds;

                if (!isPrime)
                {
                    pairs.Remove(current);
                    i--;
                }
            }

            foreach (Pairs p in pairs)
                Console.WriteLine($"{p.Number} - {p.Time} milliseconds");


            Console.Read();
        }

        public static int ReadSafeFromConsole()
        {
            int i;
            bool canConvert;

            do
            {
                string input = Console.ReadLine();
                canConvert = int.TryParse(input, out i);

                if (canConvert)
                    break;

                Console.Write("Deve essere un numero intero positivo!!! ");
            }
            while (!canConvert);

            return i;
        }

        private static void CompilationList(int inputGuess, List<int> list)
        {

            for (int i = 2; i <= inputGuess; i++)
            {
                bool isPrime = true;
                int k = (int)Math.Sqrt(i);

                for (int j = 2; j <= k; j++)
                    if (i % j == 0)
                    {
                        isPrime = false;
                        j = k;
                    }

                if (isPrime)
                    list.Add(i);
            }
        }
    }

    class Pairs
    {
        //public Pairs(int number, Stopwatch time)
        //{
        //    Number = number;
        //    Time = time;
        //}

        public int Number;
        public long Time;
    }
}
