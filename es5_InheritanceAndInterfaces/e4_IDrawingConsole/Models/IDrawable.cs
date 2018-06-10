using System;
using System.Collections.Generic;
using System.Text;

namespace e4_IDrawingConsole.Models
{
    interface IDrawable
    {
        //void Draw(Square s, Rectangle rt, Rhumbos rb, Line l);
        void Draw(IDrawable draw);
    }
}
