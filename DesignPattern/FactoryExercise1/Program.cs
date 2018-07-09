using System;
using System.Collections.Generic;

namespace FactoryExercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Hamburger> list = new List<Hamburger>();
            Hamburger h1 = CreateHamburger("Classic", Size.medium, false, true);
            Hamburger h2 = CreateHamburger("Vegan", Size.medium, true, true);
            Hamburger h3 = CreateHamburger("Chianina", Size.medium, true, false);
            Hamburger h4 = CreateHamburger("Chianina", Size.medium, true, true);

            list.Add(h1);
            list.Add(h2);
            list.Add(h3);
            list.Add(h4);

            foreach (Hamburger h in list)
            {
                Console.WriteLine("Type: " + h.GetType().Name);
                Console.WriteLine("\tSize: " + h.Size);
                Console.WriteLine("\tTomatoes Slices: " + h.TomatoesSlices);
                Console.WriteLine("\tCheese Slices: " + h.CheeseSlices + "\n\r");
            }

            Console.Read();
        }

        private static Hamburger CreateHamburger(string type, Size size, bool addTomatoes, bool addCheese)
        {
            switch(type)
            {
                case "Vegan" :
                    return new Vegan
                    {
                        Size = size,
                        TomatoesSlices = addTomatoes ? 1 : 0,
                        CheeseSlices = addCheese ? 0 : 0,
                    };
                case "Chianina" :
                    return new Chianina
                    {
                        Size = size,
                        TomatoesSlices = addTomatoes ? 2 : 0,
                        CheeseSlices = addCheese ? 1 : 0
                    };
                case "Classic":
                    return new Classic
                    {
                        Size = size,
                        TomatoesSlices = addTomatoes ? 3 : 0,
                        CheeseSlices = addCheese ? 2 : 0
                    };
                default:
                    throw new InvalidOperationException("Unknown hambuerger type");
            }
        }
    }

    class Hamburger
    {
        public Size Size { get; set; }
        public int TomatoesSlices { get; set; }
        public int CheeseSlices { get; set; }
        public decimal Price { get; set; }
    }
    
    class Vegan : Hamburger
    { }

    class Chianina : Hamburger
    { }

    class Classic : Hamburger
    { }

    enum Size
    {
        small = 1,
        medium = 2,
        large = 3,
        fat = 4
    }
}
