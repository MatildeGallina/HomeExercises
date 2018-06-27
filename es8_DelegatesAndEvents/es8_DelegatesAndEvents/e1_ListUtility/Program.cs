using System;
using System.Collections.Generic;

namespace e1_ListUtility
{
    /* Creare una classe `Item` con una propertà intera `Value`.
     * 
     * Creare un `delegate` che prende in input un parametro `Item` e restituisce un `bool`.
     * 
     * Creare due metodi statici che rispettino il delegate:
     * - il primo dice se il `Value` dentro `Item` è un numero primo
     * - il secondo dice se il `Value` dentro l'`Item` è non-negativo
     * Creare una classe di utility, `ListUtility`, che abbia dentro un metodo di "filtro".
     * Il metodo accetta in input:
     * - una lista di `Item`
     * - un delegate (definito sopra)
     * Il metodo restituisce una nuova lista con solo gli elementi filtrati. Il metodo utilizza
     *  il delegate per capire se il singolo elemento della lista originale va incluso nella lista filtrata o no.
     *  
     * Provare ad utilizzare questo metodo di utility, passando prima il metodo statico per i numeri primi, poi quello per i non-negativi.
     * 
     * Scrivere degli Unit Test che provino il comportamento della classe.
     */

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Item> items = new List<Item>()
            {
                new Item { Value = 1 },
                new Item { Value = 0 },
                new Item { Value = 3 },
                new Item { Value = -6 },
                new Item { Value = 21 },
                new Item { Value = 7 },
                new Item { Value = -9 },
                new Item { Value = 8 },
                new Item { Value = 2 }
            };

            Utility u1 = new Utility();
            List<Item> notNegatives = u1.Filter(items, isNotNegative);

            Utility u2 = new Utility();
            List<Item> primes = u2.Filter(items, isPrime);

            Console.Read();
        }

        public static bool isPrime(Item item)
        {
            bool itemPrime = true;
            int t = item.Value;

            if (t <= 1)
                itemPrime = false;
            else
                for(int i = 2;  i <= Math.Sqrt(t); i++)
                    if (t % i == 0)
                    {
                        itemPrime = false;
                        break;
                    }

            return itemPrime;
        }

        public static bool isNotNegative(Item item)
        {
            bool notNegative = true;
            if (item.Value < 0)
                notNegative = false;

            return notNegative;
        }
    }

    public class Item
    {
        public int Value { get; set; }
    }

    public class Utility
    {
        public List<Item> filteredList = new List<Item>();
        public List<Item> Filter(List<Item> items, FilterHandler filter)
        {
            foreach (Item item in items)
                if (filter(item) == true)
                    filteredList.Add(item);

            return filteredList;
        }
    }

    public delegate bool FilterHandler(Item item);
}
