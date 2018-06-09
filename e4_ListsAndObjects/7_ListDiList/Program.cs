using System;
using System.Collections.Generic;

namespace _7_ListDiList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Fino a che riga vuoi costruire il rettangolo? ");
            int l = ReadSafeLine();

            List<List<int>> list = new List<List<int>>();

            for (int i = 1; i <= l; i++)
            {
                List<int> row = new List<int>();

                for (int j = 1; j <= i; j++)
                    row.Add(j);

                list.Add(row);
            }

            Console.WriteLine("Ecco il triangolo costruito con una lista di liste: ");
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Count; j++)
                    Console.Write($"{list[i][j]} ");
                Console.WriteLine();
            }

            Console.Read();
        }

        public static int ReadSafeLine()
        {
            int l;
            bool canConvert;

            do
            {
                string input = Console.ReadLine();
                canConvert = int.TryParse(input, out l);

                if (canConvert && l > 0)
                    break;

                canConvert = false;
                Console.Write("Il numero deve essere intero, positivo e diverso da 0: ");
            }
            while (!canConvert);

            return l;
        }
    }
}
