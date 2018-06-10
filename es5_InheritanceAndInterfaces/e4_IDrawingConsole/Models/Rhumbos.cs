using System;
using System.Collections.Generic;
using System.Text;

namespace e4_IDrawingConsole.Models
{
    class Rhumbos : IDrawable
    {
        // accetta nel costruttore la lunghezza del lato
        public Rhumbos(int _side)
        {
            Side = _side;
        }

        public int Side { get; set; }

        public void Draw(IDrawable draw)
        {
            for (int j = Side; j > 0; j--)
            {
                for (int i = j; i > 0; i--)
                    Console.Write(" ");
                Console.Write("/");
                for (int k = 0; k < (Side - j); k++)
                    Console.Write("  ");
                Console.WriteLine("\\");
            }
            for (int j = 0; j < Side; j++)
            {
                Console.Write(" ");
                for (int i = 0; i < j; i++)
                    Console.Write(" ");
                Console.Write("\\");
                for (int k = (Side - j); k > 1; k--)
                    Console.Write("  ");
                Console.WriteLine("/");
            }

            Console.WriteLine("\n\r");
        }
    }
}
