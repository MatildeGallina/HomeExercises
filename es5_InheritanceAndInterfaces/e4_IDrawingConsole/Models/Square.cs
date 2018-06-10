using System;
using System.Collections.Generic;
using System.Text;

namespace e4_IDrawingConsole.Models
{
    class Square : IDrawable
    {
        // accetta nel costruttore lunghezza lato
        public Square(int _side)
        {
            Side = _side;
        }

        public int Side { get; set; }

        public void Draw(IDrawable draw)
        {
            for (int i = 0; i <= Side; i++)
            {
                if (i == 0)
                {
                    Console.Write(" ");
                    for (int j = 0; j < Side; j++)
                        Console.Write("__");
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("|");
                    if (i == (Side))
                    {
                        for (int j = 0; j < Side; j++)
                            Console.Write("__");
                    }
                    else
                        for (int j = 0; j < Side; j++)
                            Console.Write("  ");
                    Console.WriteLine("|");
                }
            }

            Console.WriteLine("\n\r");
        }
    }
}
