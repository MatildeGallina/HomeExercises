using System;
using System.Collections.Generic;
using System.Text;

namespace e8_Tria
{
    public class PersonPlayer : IPlayer
    {
        public PersonPlayer(string name, string sign)
        {
            Name = name;
            Sign = sign;
        }

        public string Name { get; set; }
        public string Sign { get; set; }

        public int ReadSafeInt()
        {
            int l;
            bool canConvert;

            do
            {
                string input = Console.ReadLine();
                canConvert = int.TryParse(input, out l);

                if (canConvert && l > 0 && l < 4)
                    break;
                else
                    canConvert = false;

                Console.WriteLine("La scelta della riga deve essere un numero tra 1 e 3.");
                Console.Write("Inserisci una riga valida: ");
            }
            while (!canConvert);

            return l;
        }

        public List<int> ValidChoice(List<List<string>> board)
        {
            List<int> coordinates = new List<int>();
            bool validChoice = false;
            int row;
            int line;

            do
            {
                Console.Write("Scegli il numero di riga: ");
                line = ReadSafeInt() - 1;

                Console.Write("Scegli il numero della colonna: ");
                row = ReadSafeInt() - 1;

                if (board[line][row] == " ")
                    break;

                ValidChoice(board);

                Console.Write("La casella è già occupata!\n\r" +
                        "Fai un'altra scelta!");
            }
            while (!validChoice);

            coordinates.Add(line);
            coordinates.Add(row);

            return coordinates;
        }
    }
}
