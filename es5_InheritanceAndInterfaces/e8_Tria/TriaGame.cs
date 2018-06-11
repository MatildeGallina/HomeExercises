using System;
using System.Collections.Generic;
using System.Text;

namespace e8_Tria
{
    public class TriaGame
    {
        public void StartGame(PersonPlayer p1, PersonPlayer p2)
        {
            List<List<string>> board = new List<List<string>>();
            board = CreateNewBoard(board);

            
            int round = 1;

            while (true)
            {
                Console.WriteLine($"ROUND {round}");

                Console.WriteLine($"E' il turno di {p1.Name}:");

                List<int> coordinatesp1 = p1.ValidChoice(board);

                board[coordinatesp1[0]][coordinatesp1[1]] = p1.Sign;

                PrintList(board);

                bool p1Wins = SomeOneWin(board);
                if(p1Wins)
                {
                    Console.WriteLine($"{p1.Name}: 'HO VINTOOO!'");
                    break;
                }

                Console.WriteLine($"E' il turno di {p2.Name}:");

                List<int> coordinatesp2 = p2.ValidChoice(board);

                board[coordinatesp2[0]][coordinatesp2[1]] = p2.Sign;

                PrintList(board);

                bool p2Wins = SomeOneWin(board);
                if (p2Wins)
                {
                    Console.WriteLine($"{p2.Name}: 'HO VINTOOO!'");
                }

                round++;
                if(round == 10 && p1Wins == p2Wins)
                {
                    Console.WriteLine("GAME OVER, NO ONE WIN...");
                    break;
                }
            }
        }

        public List<List<string>> CreateNewBoard(List<List<string>> board)
        {
            List<string> row1 = new List<string>{ " ", " ", " "};
            board.Add(row1);

            List<string> row2 = new List<string> { " ", " ", " " };
            board.Add(row2);

            List<string> row3 = new List<string> { " ", " ", " " };
            board.Add(row3);

            return board;
        }

        public void PrintList(List<List<string>> board)
        {
            for(int i = 0; i < board.Count; i++)
            {
                for(int j = 0; j < board.Count; j++)
                    Console.Write($"{board[i][j]} ");
                Console.WriteLine();
            }
        }

        public bool SomeOneWin(List<List<string>> board)
        {
            bool someOneWins = false;

            for(int i = 0; i < board.Count; i++)
                if ((board[i][0] == board[i][1] && board[i][1] == board[i][2] && board[i][0] == "x" && board[i][0] == "o") ||
                    (board[0][i] == board[1][i] && board[1][i] == board[2][i] && board[0][i] == "x" && board[0][i] == "o") ||
                    (board[0][0] == board[1][1] && board[1][1] == board[2][2] && board[0][0] == "x" && board[0][0] == "o") ||
                    (board[2][0] == board[1][1] && board[1][1] == board[0][2] && board[2][0] == "x" && board[2][0] == "o"))
                    someOneWins = true;

            return someOneWins;
        } 
    }
}
