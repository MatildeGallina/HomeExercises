using System;
using System.Collections.Generic;

namespace _3_Wall
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("There's a Class: \"Wall\" containing width and height, and a method for calculate the surface." +
                "\n\rThere's a List containing 4 walls." +
                "\n\rThis program calculate the surface of a room");

            while (true)
            {
                List<Wall> list = CreateList();

                double totalSurface = CalculateTotaleSurface(list);

                Console.WriteLine($"The surface of the four walls you entered is {totalSurface}.");

                Console.Write("Do you want to calculate the surface of another room (Y/N)? ");
                string mustContinue = Console.ReadLine();
                if (mustContinue == "N")
                    break;
            }
        }
        static double ReadSafe()
        {
            double n;
            bool canConvert;

            do
            {
                string input = Console.ReadLine();
                canConvert = double.TryParse(input, out n);

                if (!canConvert)
                    Console.Write("Enter a valid number: ");
            }
            while (!canConvert);

            return n;
        }
        static Wall ReadDataFromConsole()
        {
            Wall w = new Wall();

            Console.Write("What's the width of the wall? ");
            w.Width = ReadSafe();

            Console.Write("What's the height of the wall? ");
            w.Height = ReadSafe();

            return w;
        }
        static List<Wall> CreateList()
        {
            List<Wall> list = new List<Wall>();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Wall n.{i + 1}:");
                list.Add(ReadDataFromConsole());
            }

            return list;
        }
        static double CalculateTotaleSurface(List<Wall> list)
        {
            double totalSurface = 0;
            string s;

            foreach (Wall w in list)
            {
                s = $"{ w.Height * w.Width }";
                double surface = double.Parse(s);

                totalSurface = totalSurface + surface;
            }
            return totalSurface;
        }
    }
    class Wall
    {
        public double Width;
        public double Height;

        public static double CalculateSurface(double Width, double Height)
        {
            double surface = Width * Height;

            return surface;
        }
    }
}
