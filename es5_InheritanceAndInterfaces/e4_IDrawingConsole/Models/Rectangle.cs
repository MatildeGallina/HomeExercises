using System;
using System.Collections.Generic;
using System.Text;

namespace e4_IDrawingConsole.Models
{
    class Rectangle : IDrawable
    {
        // accetta nel costruttore base e altezza
        public Rectangle(int _base, int _heigth)
        {
            Base = _base;
            Heigth = _heigth;
        }

        public int Base { get; set; }
        public int Heigth { get; set; }

        public void Draw(IDrawable draw)
        {
            for (int i = 0; i <= Heigth; i++)
            {
                if (i == 0)
                {
                    Console.Write(" ");
                    for (int j = 0; j < Base; j++)
                        Console.Write("__");
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("|");
                    if (i == (Heigth))
                    {
                        for (int j = 0; j < Base; j++)
                            Console.Write("__");
                    }
                    else
                        for (int j = 0; j < Base; j++)
                            Console.Write("  ");
                    Console.WriteLine("|");
                }
            }

            Console.WriteLine("\n\r");
        }
    }
}
