using System;
using System.Collections.Generic;
using e4_IDrawingConsole.Models;

namespace e4_IDrawingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Creare un'interfaccia `IDrawable` con un metodo `Draw()`.
             * A implementare l'interfaccia devono essere le seguenti classi:
             * - uno `Square`, che accetta nel costruttore la lunghezza del lato
             * - un `Rectangle`, che accetta nel costruttore base e altezza
             * - un `Rhombus`, che accetta nel costruttore la lunghezza del lato
             * - una `Line`, che accetta nel costruttore la lunghezza, e l'indicazione se è orizzontale o verticale

             * Tutte queste classi devono saper disegnare la propria forma sulla `Console`.
             * Ad esempio una linea orizzontale lunga 5 dovrà, nel metodo `Draw()`, disegnare: `_____`.

             * Creare una lista hard-coded di oggetti `IDrawable`, poi eseguire un foreach chiamando su ogni istanza
             * il metodo `Draw()`.
             * Quadrato e Rettangolo sono banali. Per il Rombo, usare i caratteri `/` e `\`.
             */
            
            IDrawable rt1 = new Rectangle(5, 3);
            IDrawable rb1 = new Rhumbos(3);
            IDrawable s1 = new Square(4);
            IDrawable l1 = new Line(3, PositionIndication.Vertical);
            IDrawable l2 = new Line(8, PositionIndication.Horizontal);
            IDrawable rb2 = new Rhumbos(8);
            
            List<IDrawable> draws = new List<IDrawable>
            {
                rt1,
                rb1,
                s1,
                l1,
                l2,
                rb2
            };

            foreach(IDrawable draw in draws)
            {
                draw.Draw(draw);
            }

            Console.Read();
        }
    }
}
