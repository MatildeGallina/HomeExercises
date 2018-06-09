using System;
using System.Collections.Generic;
using System.Linq;

namespace _6_Smartphone
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ho una lista di smartphone con le informazioni utili.");

            List<Smartphone> list = ListOfSmartphone();

            Console.WriteLine("Che colore di Smartphone vuoi selezionare?");
            Console.Write($"({Color.Black}, {Color.Blue}, {Color.Gold}, {Color.Grey}, {Color.Pink}," +
                $" {Color.SideralGrey}, {Color.Silver}, {Color.White}, {Color.Yellow}) ");

            Color selectedColor = ReadSafeEnum();

            for (int i = 0; i < list.Count; i++)
                if (list[i].Color != selectedColor)
                {
                    list.Remove(list[i]);
                    i--;
                }

            if(list.Count == 0)
                Console.WriteLine("Mi dispiace, non ho in elenco telefoni di quel colore");
            else
            {
                Console.WriteLine($"Questi sono gli smartphone che ho in elencon con il colore selezionalto:");
                foreach(Smartphone s in list)
                {
                    Console.WriteLine($"Modello {s.Model}, Versione {s.Version}, Costo {s.Cost}");
                }
            }

            Console.WriteLine("Posso fare una ricerca anche per prezzo.");

            Console.Write("Qual è il prezzo limite? ");
            double limit = ReadSafeDouble();

            Console.WriteLine("Vuoi che trovi quelli col prezzo maggiore o minore?");
            Console.Write("(maggiore / minore)");
            string choice = ReadSaceChoice();

            list = ListOfSmartphone();

            switch (choice)
            {
                case "maggiore": 
                    for(int i = 0; i < list.Count; i++)
                        if (list[i].Cost < limit)
                        {
                            list.Remove(list[i]);
                            i--;
                        }
                    break;
                case "minore":
                    for (int i = 0; i < list.Count; i++)
                        if (list[i].Cost > limit)
                        {
                            list.Remove(list[i]);
                            i--;
                        }
                    break;
            }

            Console.WriteLine($"Ecco la lista dei telefoni che hanno un costo {choice} di {limit}:");
            foreach(Smartphone s in list)
                Console.WriteLine($"Modello {s.Model}, Versione {s.Version}, Colore {s.Color}");

            Console.Read();
        }

        private static List<Smartphone> ListOfSmartphone()
        {
            List<Smartphone> list = new List<Smartphone>();

            Smartphone s1 = new Smartphone();
            s1.Model = "P10 Dual AL00 128GB";
            s1.Version = Version.Andoid_7_0;
            s1.Cost = 389.99;
            s1.Color = Color.Black;
            list.Add(s1);

            Smartphone s2 = new Smartphone();
            s2.Model = "P10 Dual TL00 64GB";
            s2.Version = Version.Andoid_7_0;
            s2.Cost = 250.00;
            s2.Color = Color.Black;
            list.Add(s2);

            Smartphone s3 = new Smartphone();
            s3.Model = "P10 L09 64GB";
            s3.Version = Version.Andoid_7_0;
            s3.Cost = 251.99;
            s3.Color = Color.Black;
            list.Add(s3);

            Smartphone s4 = new Smartphone();
            s4.Model = "PRA-LX1";
            s4.Version = Version.Andoid_7_0;
            s4.Cost = 299.99;
            s4.Color = Color.White;
            list.Add(s4);

            Smartphone s5 = new Smartphone();
            s5.Model = "A1863";
            s5.Version = Version.iOS_11;
            s5.Cost = 650.00;
            s5.Color = Color.SideralGrey;
            list.Add(s5);

            Smartphone s6 = new Smartphone();
            s6.Model = "A1901";
            s6.Version = Version.iOS_11;
            s6.Cost = 649.99;
            s6.Color = Color.SideralGrey;
            list.Add(s6);

            Smartphone s7 = new Smartphone();
            s7.Model = "L950";
            s7.Version = Version.Windows_Phone_10;
            s7.Cost = 500.00;
            s7.Color = Color.Silver;
            list.Add(s7);

            Smartphone s8 = new Smartphone();
            s8.Model = "L640XL";
            s8.Version = Version.Windows_Phone_10;
            s8.Cost = 519.99;
            s8.Color = Color.Gold;
            list.Add(s8);

            Smartphone s9 = new Smartphone();
            s9.Model = "L535";
            s9.Version = Version.Windows_Phone_10;
            s9.Cost = 400.00;
            s9.Color = Color.Gold;
            list.Add(s9);

            return list;
        }

        private static Color ReadSafeEnum()
        {
            Color c;
            bool canConvert;

            do
            {
                string input = Console.ReadLine();
                canConvert = Enum.TryParse<Color>(input, out c);

                if (canConvert)
                    break;

                Console.Write("Devi fare una scelta valida tra quelle proposte.\n\r" +
                    "Inserisci nuovamente: ");
            }
            while (!canConvert);

            return c;
        }

        private static double ReadSafeDouble()
        {
            double d;
            bool canConvert;

            do
            {
                string input = Console.ReadLine();
                canConvert = double.TryParse(input, out d);

                if (canConvert)
                    break;

                Console.WriteLine("Devi inserirmi un importo valido!!\n\r Inserisci di nuovo: ");
            }
            while (!canConvert);

            return d;
        }

        private static string ReadSaceChoice()
        {
            string input;
            do
            {
                input = Console.ReadLine();
                if (input == "maggiore" || input == "minore")
                    break;

                Console.Write("Devi fare una scleta valida tra: maggiore / minore\n\r" +
                    "Fai la tua scelta: ");
            }
            while (true);

            return input;
        }
    }

    class Smartphone
    {
        public string Model;
        public Version Version;
        public double Cost;
        public Color Color;
    }

    enum Version
    {
        Andoid_7_0,
        Windows_Phone_10,
        iOS_11
    }

    enum Color
    {
        White,
        Black,
        Grey,
        SideralGrey,
        Gold,
        Silver,
        Yellow,
        Pink,
        Blue
    }
}
