using System;
using System.Collections.Generic;
using System.Text;

namespace e4_IDrawingConsole.Models
{
    class Line : IDrawable
    {
        // acceta nel costruttore la lunghezza e l'indicazione se è orizzontale o verticale
        public Line(int _length, PositionIndication _position)
        {
            Length = _length;
            Position = _position;
        }

        public int Length { get; set; }
        public PositionIndication Position;

        public void Draw(IDrawable draw)
        {
            if (this.Position == PositionIndication.Vertical)
                for (int i = 0; i < Length; i++)
                    Console.WriteLine("|");
            else
                for (int i = 0; i < Length; i++)
                    Console.Write("__");

            Console.WriteLine("\n\r");
        }
    }

    public enum PositionIndication
    {
        Vertical,
        Horizontal
    }

}
