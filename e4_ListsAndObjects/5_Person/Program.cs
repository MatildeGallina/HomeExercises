using System;
using System.Collections.Generic;

namespace _5_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Quante persone vuoi aggiungere a questa tabella? ");
            int nPerson = ReadSafeFromConsole();

            List<Person> list = CreateListPerson(nPerson);

            Console.WriteLine("Ecco le informazioni che hai inserito:");
            Print(list);

            Console.Read();
        }

        private static int ReadSafeFromConsole()
        {
            int n;
            bool canConvert;

            do
            {
                string input = Console.ReadLine();
                canConvert = int.TryParse(input, out n);

                if (canConvert)
                    break;

                Console.Write("Deve essere un numero intero positivo, inserisci di nuov: ");
            }
            while (!canConvert);

            return n;
        }

        private static List<Person> CreateListPerson(int nPerson)
        {
            List<Person> list = new List<Person>();

            for (int j = 0; j < nPerson; j++)
            {
                Person p = new Person();

                Console.WriteLine($"Dati persona n. {j + 1}");

                Console.Write("Nome: ");
                p.Name = Console.ReadLine();
                Console.Write("Cognome: ");
                p.Surname = Console.ReadLine();
                Console.Write("Altezza (cm): ");
                p.Heigth = ReadSafeFromConsole();

                Adress adress = AdressInformation();
                p.Adress = adress;
                
                Console.Write("Quante auto possiede? ");
                int nCar = ReadSafeFromConsole();

                List<Car> car = CreateListCar(nCar);
                p.Car = car;

                list.Add(p);
            }

            return list;
        }

        private static Adress AdressInformation()
        {
            Adress adress = new Adress();

            Console.Write("Via: ");
            adress.Street = Console.ReadLine();
            Console.Write("Numero: ");
            adress.Number = ReadSafeFromConsole();
            Console.Write("CAP: ");
            adress.CAP = ReadSafeFromConsole();
            Console.Write("Città: ");
            adress.City = Console.ReadLine();
            return adress;
        }

        private static List<Car> CreateListCar(int nCar)
        {
            List<Car> car = new List<Car>();

            for (int i = 0; i < nCar; i++)
            {
                Car c = new Car();
                Console.WriteLine($"Dati auto n. {i + 1}");

                Console.Write("Marca: ");
                c.Brand = Console.ReadLine();
                Console.Write("Modello: ");
                c.Model = Console.ReadLine();
                Console.Write("Cilindrata (cm3): ");
                c.Displacement = ReadSafeFromConsole();

                car.Add(c);
            }

            return car;
        }

        private static void Print(List<Person> list)
        {
            foreach (Person p in list)
            {
                int n = list.IndexOf(p) + 1;
                Console.WriteLine($"Informazioni persona n. {n}:");
                Console.WriteLine($"\tNome: {p.Name};");
                Console.WriteLine($"\tCognome: {p.Surname};");
                Console.WriteLine($"\tAltezza (cm): {p.Heigth};");

                Console.WriteLine("\tRisiede all'indirizzo:\n\r" +
                    $"\t\tvia: {p.Adress.Street}, {p.Adress.Number}\n\r" +
                    $"\t\t{p.Adress.City}, C.A.P. {p.Adress.CAP}");

                Console.Write($"\tPossiede:\n\r");
                for (int i = 0; i < p.Car.Count; i++)
                {
                    Console.WriteLine($"\tAuto n. {i + 1}:");
                    Console.WriteLine($"\t\tMarca: {p.Car[i].Brand}");
                    Console.WriteLine($"\t\tModello: {p.Car[i].Model}");
                    Console.WriteLine($"\t\tCilindrata (cm3): {p.Car[i].Displacement}\n\r");
                }
            }
        }
    }

    class Person
    {
        public string Name;
        public string Surname;
        public int Heigth;
        public Adress Adress;
        public List<Car> Car;
    }

    class Adress
    {
        public string Street;
        public int Number;
        public int CAP;
        public string City;
    }

    class Car
    {
        public string Model;
        public string Brand;
        public int Displacement;
    }
}
