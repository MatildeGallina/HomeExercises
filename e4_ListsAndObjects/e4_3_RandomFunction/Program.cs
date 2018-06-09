using System;

namespace e4_3_RandomFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Ho pensato a un numero da 1 a 10.");
                Console.WriteLine("Prova a indovinarlo, hai 5 tentativi.");

                Random r = new Random();

                int rand = r.Next(1, 10);

                for (int i = 1; i <= 5; i++)
                {
                    Console.Write($"Tentativo numero {i}: ");
                    int guess = ReadSafeFromConsole();

                    if (guess == rand)
                    {
                        Console.WriteLine("Bravo, hai vinto!!!");
                        break;
                    }
                    else if (i == 5)
                    {
                        Console.WriteLine($"Era il tuo ultimo tentativo, avevo pensato al numero {rand}!!!");
                        Console.WriteLine("GAME OVER!!!");
                        break;
                    }
                    else
                        Console.WriteLine($"Ritenta... hai ancora {5 - i} tentativi...");
                }

                Console.Write("Vuoi iniziare una nuova partita? (S/N) ");
                string endGame = Console.ReadLine();

                if (endGame == "N")
                    break;

            }
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

                Console.WriteLine("Devi inserire un numero intero da 1 a 10!!!");
            }
            while (!canConvert);

            return i;
        }
    }
}
